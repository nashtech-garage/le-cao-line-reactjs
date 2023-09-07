
using Quiz.API;
using Quiz.Application;
using Quiz.Infrastructure;
using Quiz.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

GlobalMongoRegistration.Register();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MongoDatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
