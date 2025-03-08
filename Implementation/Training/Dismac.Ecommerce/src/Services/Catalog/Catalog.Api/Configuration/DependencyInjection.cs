using Catalog.Persistence.Database;
using Catalog.Service.EventHandler.Commands;
using Catalog.Service.Queries;
using HealthChecks.UI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Service.Shared.Logging;

namespace Catalog.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCatalogServiceConfiguration(
            this IServiceCollection services,
            IConfiguration configuration,
            ILoggingBuilder loggingBuilder,
            WebApplicationBuilder builder) 
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

            //Logging (Papertrail)
            PapertrailSetup(configuration, loggingBuilder, builder);

            //Healtcheck
            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddDbContextCheck<CatalogDbContext>();

            var sqliteConnectionString = configuration.GetValue<string>("HealthChecksUI:HealthCheckDatabaseConnectionString");

            services.AddHealthChecksUI()
                .AddSqliteStorage(sqliteConnectionString);

            return services;
        }

        private static void PapertrailSetup(
            IConfiguration configuration,
            ILoggingBuilder loggingBuilder,
            WebApplicationBuilder builder)
        {
            var papertrailConfig = configuration.GetSection("Papertrail");
            string papertrailHost = papertrailConfig["host"];
            int papertrailPort = Convert.ToInt32(papertrailConfig["port"]);

            if (builder.Environment.IsProduction())
            {
                loggingBuilder.AddProvider(
                    new SyslogLoggerProvider(
                        papertrailHost,
                        papertrailPort,
                        null));
            }
        }
    }
}
