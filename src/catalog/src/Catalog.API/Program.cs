using Autofac;
using Autofac.Extensions.DependencyInjection;
using Catalog.API;
using Catalog.API.Application.IntegrationEvents.Events;
using Catalog.API.Infrastructure.AutofacModules;
using Catalog.API.Infrastructure.Extensions;
using Catalog.API.Infrastructure.Filters;
using Catalog.API.Infrastructure.Services;
using Catalog.Infrastructure;
using Confluent.Kafka;
using EventBus;
using EventBus.Abstractions;
using EventBus.EventBusServiceBus;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Text.Json.Serialization;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

IdentityModelEventSource.ShowPII = true;

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyHeader().AllowAnyMethod();
        });
});

//
var kafkaSettings = new KafkaSettings();
builder.Configuration.GetSection("KafkaSettings").Bind(kafkaSettings);

//
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<CatalogContext>(options =>
    {
        options.UseNpgsql(connectionString,
            npgsqlOptionsAction: sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorCodesToAdd: null);
            });
    },
    ServiceLifetime
        .Scoped //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
// setup service discovery
builder.Services.AddOptions<ServiceConfig>().BindConfiguration("ServiceConfig");
var serviceConfig = new ServiceConfig();
builder.Configuration.GetSection("ServiceConfig").Bind(serviceConfig);
builder.Services.RegisterConsulServices(serviceConfig);
// setup autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(container =>
{
    container.RegisterModule(new MediatorModule());
    container.RegisterModule(new ApplicationModule(connectionString));
}));

// event bus
builder.Services.AddSingleton<IPublishEvent>(x =>
{
    var config = new ProducerConfig
    {
        BootstrapServers = kafkaSettings.BootstrapServers,
        ClientId = Dns.GetHostName()
    };
    IProducer<string, byte[]> producer = new ProducerBuilder<string, byte[]>(config).Build();
    return new KafkaPublishEvent(kafkaSettings.PublishTopic, producer);
});

builder.Services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

builder.Services.AddSingleton<ISubscribeEvent>(x =>
{
    var config = new ConsumerConfig()
    {
        GroupId = kafkaSettings.GroupId,
        BootstrapServers = kafkaSettings.BootstrapServers,
        AutoOffsetReset = AutoOffsetReset.Earliest
    };
    var iLifetimeScope = x.GetRequiredService<ILifetimeScope>();
    var eventBusSubcriptionsManager = x.GetRequiredService<IEventBusSubscriptionsManager>();

    return new KafkaSubscribeEvent(eventBusSubcriptionsManager, iLifetimeScope, config, kafkaSettings.SubscribeTopic);
});
//builder.Services.AddSingleton<IHostedService, KafkaConsumerService>();
builder.Services.AddHostedService<KafkaConsumerService>();
// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services
    .AddControllers(options => { options.Filters.Add(typeof(HttpGlobalExceptionFilter)); })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Catalog React Team HTTP API",
        Version = "v1",
        Description = "The Catalog Service HTTP API"
    });

    options.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter into field the word 'Bearer' following by space and JWT",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "AuthKey"
        });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "Bearer",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
    options.OperationFilter<AuthorizeCheckOperationFilter>();
});

// auth
// prevent from mapping "sub" claim to nameidentifier.
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

var audienceConfig = new KeycloakSetting();
builder.Configuration.GetSection("KeycloakSetting").Bind(audienceConfig);

var tokenValidationParameters = new TokenValidationParameters
{
    ValidateAudience = false,
    ValidateIssuer = true,
    ValidIssuer = audienceConfig.AuthorityUrl,
    ValidateLifetime = true,
    ClockSkew = TimeSpan.Zero,
    RequireExpirationTime = true
};

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = audienceConfig.AuthorityUrl;
        options.Audience = audienceConfig.ClientId;
        options.SaveToken = true;
        options.IncludeErrorDetails = true;
        options.RequireHttpsMetadata = false;

        options.TokenValidationParameters = tokenValidationParameters;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
        policy.RequireClaim(ClaimTypes.Role, "admin"));
    options.AddPolicy("User", policy =>
        policy.RequireClaim(ClaimTypes.Role, "user"));
    options.AddPolicy("AdminOrUser", policy =>
        policy.RequireClaim(ClaimTypes.Role, "user", "admin"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// subscibe event
var eventBus = app.Services.GetRequiredService<ISubscribeEvent>();
eventBus.Subscribe<OrderSuccessIntegrationEvent, IIntegrationEventHandler<OrderSuccessIntegrationEvent>>();

////Seed data
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    try
//    {
//        var context = services.GetRequiredService<CatalogContext>();
//        var logger = services.GetService<ILogger<CatalogContextSeed>>();
//        CatalogContextSeed
//            .SeedAsync(context, logger)
//            .Wait();
//    }
//    catch (Exception ex)
//    {
//        var logger = services.GetRequiredService<ILogger<Program>>();
//        logger.LogError(ex, "An error occurred while seeding the database.");
//    }
//}
app.Run();