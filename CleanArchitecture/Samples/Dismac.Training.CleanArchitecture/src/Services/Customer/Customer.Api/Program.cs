using Customer.Api.Application.Interfaces.Messaging;
using Customer.Api.Config;
using Customer.Api.Infrastructure.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Inyección de dependencias
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
//// Add Messaging Services
//builder.Services.AddSingleton<IMessagePublisher, RabbitMQPublisher>();
//builder.Services.AddHostedService<RabbitMQConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
