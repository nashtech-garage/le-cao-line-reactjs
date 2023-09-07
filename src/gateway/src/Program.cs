using Ocelot.Values;
using ApiGateway;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Ocelot.Middleware;
using Ocelot.DependencyInjection;
using Ocelot.Provider.Consul;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json");
//
builder.Services.AddCors(options =>
{
    options.AddPolicy("cors",
        builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials());
});
// Add services to the container.
builder.Services.AddOptions<ServiceConfig>().BindConfiguration("ServiceConfig");
var serviceConfig = new ServiceConfig();
builder.Configuration.GetSection("ServiceConfig").Bind(serviceConfig);
builder.Services.RegisterConsulServices(serviceConfig);
//
builder.Services.AddOcelot()
    .AddConsul();
//
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();
builder.Services.AddAuthorization();
//
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        {
            var services = builder.Configuration.GetSection("services").Get<string[]>();
            if (services != null)
            {
                foreach (var service in services)
                {
                    c.SwaggerEndpoint($"/{service}/swagger/v1/swagger.json", service);
                }
            }
        });
}
app.UseCors("cors");
app.UseRouting();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.UseOcelot().Wait();
app.Run();
