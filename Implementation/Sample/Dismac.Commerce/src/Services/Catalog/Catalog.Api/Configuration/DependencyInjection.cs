using Catalog.Persistence.Database;
using Catalog.Service.EventHandler;
using Catalog.Service.Queries;
using Microsoft.EntityFrameworkCore;
using Service.Common.Logging;

namespace Customer.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddComponentsRequired(this IServiceCollection services, IConfiguration config, ILoggingBuilder loggingBuilder)
        {
            services.AddDbContext<ApplicationDbContext>(
                 opts =>
                 opts.UseSqlServer(
                     config.GetConnectionString("DefaultConnection"),
                     x => x.MigrationsHistoryTable("_EFMigrationHistory", "Catalog")
                     ));

            services.AddTransient<IProductQueryService, ProductQueryService>();
            services.AddTransient<IProductInStockQueryService, ProductInStockQueryService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ProductCreateEventHandler).Assembly));
            PapertrailLoggerSetup(config, loggingBuilder);

            return services;
        }

        private static void PapertrailLoggerSetup(IConfiguration config, ILoggingBuilder loggingBuilder)
        {
            var papertrailConfig = config.GetSection("Papertrail");
            string papertrailHost = papertrailConfig["host"];
            int papertrailPort = Convert.ToInt32(papertrailConfig["port"]);

            loggingBuilder.AddProvider(
                new SyslogLoggerProvider(
                    papertrailHost,
                    papertrailPort,
                    null));
        }
    }
}
