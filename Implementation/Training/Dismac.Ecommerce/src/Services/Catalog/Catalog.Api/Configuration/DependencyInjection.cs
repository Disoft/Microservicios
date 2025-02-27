using Catalog.Persistence.Database;
using Catalog.Service.EventHandler.Commands;
using Catalog.Service.Queries;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCatalogServiceConfiguration(this IServiceCollection services, IConfiguration configuration) 
        {
            //DbContext configuration
            services.AddDbContext<CatalogDbContext>(
                options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("CatalogConnection"),
                    x => x.MigrationsHistoryTable("_EFMigrationHistory", "Catalog")
                    ));

            // Queries services
            services.AddTransient<IProductQueryService, ProductQueryService>();
            services.AddTransient<IProductInStockQueryService, ProductInStockQueryService>();

            // Commands services
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ProductCreateCommand).Assembly));


            return services;
        }
    }
}
