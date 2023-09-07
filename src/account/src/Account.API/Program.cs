using Autofac;
using Autofac.Extensions.DependencyInjection;
using Account.API;
using Account.API.Infrastructure.AutofacModules;
using Account.API.Infrastructure.Filters;
using Account.API.Infrastructure.Services;
using Account.Infrastructure;
using Confluent.Kafka;
using EventBus;
using EventBus.Abstractions;
using EventBus.EventBusServiceBus;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using Account.API.Models;
using Account.API.Infrastructure.Extensions;
using Account.API.Infrastructure.DelegatingHandlers;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*")
                          .AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddOptions<KeycloakSetting>().BindConfiguration("KeycloakSetting");
builder.Services.AddOptions<KafkaSettings>().BindConfiguration("KafkaSettings");
//
var kafkaSettings = new KafkaSettings();
builder.Configuration.GetSection("KafkaSettings").Bind(kafkaSettings);
builder.Services.AddSingleton<ProducerConfig>(x => new ProducerConfig()
{
    BootstrapServers = kafkaSettings.BootstrapServers,
    ClientId = Dns.GetHostName()
});
//
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AccountContext>(options =>
{
    options.UseNpgsql(connectionString,
        npgsqlOptionsAction: sqlOptions =>
        {
            sqlOptions.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
        });
},
                       ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
                   );
builder.Services.AddHttpClient("extendedhandlerlifetime").SetHandlerLifetime(TimeSpan.FromMinutes(5));
builder.Services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
//
builder.Services.AddHttpClient<IKeycloakAdminService, KeycloakAdminService>()
       .SetHandlerLifetime(TimeSpan.FromMinutes(5))
       .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
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
//binding setting
builder.Services.Configure<Audience>(builder.Configuration.GetSection("Audience"));
//builder.Services.AddSingleton<IHostedService, KafkaConsumerService>();
builder.Services.AddHostedService<KafkaConsumerService>();
// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Account React Team HTTP API",
        Version = "v1",
        Description = "The Account Service HTTP API"
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
app.Run();
