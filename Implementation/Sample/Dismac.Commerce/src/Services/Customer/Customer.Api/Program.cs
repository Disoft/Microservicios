using Customer.Persistence.Database;
using Customer.Service.EventHandler.Commands;
using Microsoft.EntityFrameworkCore;
using Order.Service.Queries;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Event handlers
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ClientCreateCommand).Assembly));

// Query services
builder.Services.AddTransient<IClientQueryService, ClientQueryService>();

// Database
builder.Services.AddDbContext<CustomerDbContext>(
options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("CustomerConnection"),
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Customer")
                )
            );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
