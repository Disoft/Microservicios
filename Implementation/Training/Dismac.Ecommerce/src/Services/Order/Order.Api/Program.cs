using Microsoft.EntityFrameworkCore;
using Order.Persistence.Database;
using Order.Service.EventHandlers;
using Order.Service.Proxy;
using Order.Service.Proxy.Catalog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// DbContext
builder.Services.AddDbContext<OrderDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsHistoryTable("_EFMigrationsHistory", "Order")
    )
);

// ApiUrls
builder.Services.Configure<ApiUrls>(opts => builder.Configuration.GetSection("ApiUrls").Bind(opts));

// Azure services bus connection string
builder.Services.Configure<AzureServiceBus>(opts => builder.Configuration.GetSection("AzureServicesBus").Bind(opts));

// Proxies
//Sync Communication
builder.Services.AddHttpClient<ICatalogProxy, CatalogHttpProxy>();
//Async Communication
//builder.Services.AddTransient<ICatalogProxy, CatalogQueueProxy>();


// Event handlers
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(OrderCreateEventHandler).Assembly));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
