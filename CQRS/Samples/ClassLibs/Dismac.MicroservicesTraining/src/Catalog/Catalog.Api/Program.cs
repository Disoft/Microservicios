using Catalog.Persistence.Database;
using Catalog.Service.Queries;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Drakesoft - add the var for accessing the appsetings configurations.
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Drakesoft - Add the Catalog DB context.
builder.Services.AddDbContext<ApplicationDbContext>(
    opts =>
    opts.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection"),
        //_EFMigrationHistory is created by each schema.
        x => x.MigrationsHistoryTable("_EFMigrationHistory", "Catalog")
        ));

// Dependency injection
builder.Services.AddMediatR(Assembly.Load("Catalog.Service.EventHandler"));

builder.Services.AddTransient<IProductQueryService, ProductQueryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
