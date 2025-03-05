using Customer.Api.Configuration;
using HealthChecks.UI.Client;
using HealthChecks.UI.Data;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Service.Common.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddComponentsRequired(builder.Configuration, builder.Logging, builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
}

app.UseAuthorization();

//Healthcheck

// Enable HealthChecks UI
//app.UseHealthChecksUI(config => config.UIPath = "/hc-ui");

app.MapHealthChecks("/hc", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecksUI();
//HealthCheck

app.MapControllers();

app.Run();
