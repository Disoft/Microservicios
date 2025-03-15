using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Order.Persistence.Database;
using Order.Service.EventHandlers;
using Order.Service.Proxy;
using Order.Service.Proxy.Catalog;
using Order.Service.Queries;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// HttpContextAccesor
builder.Services.AddHttpContextAccessor();

// DbContext
builder.Services.AddDbContext<OrderDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsHistoryTable("_EFMigrationsHistory", "Order")
    )
);

// Add Authentication
var secretKey = Encoding.ASCII.GetBytes(
    builder.Configuration.GetValue<string>("SecretKey")
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

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

// Queries
builder.Services.AddTransient<IOrderQueryService, OrderQueryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
