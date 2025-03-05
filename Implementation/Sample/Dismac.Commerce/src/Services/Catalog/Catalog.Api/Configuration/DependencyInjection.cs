using Catalog.Persistence.Database;
using Catalog.Service.EventHandler;
using Catalog.Service.Queries;
using HealthChecks.UI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Service.Common.Logging;

namespace Customer.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddComponentsRequired(this IServiceCollection services, IConfiguration config, ILoggingBuilder loggingBuilder, WebApplicationBuilder? builder)
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
            PapertrailLoggerSetup(config, loggingBuilder, builder);

            //HealthChecks

            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddDbContextCheck<ApplicationDbContext>();

            var sqliteConnectionString = config.GetValue<string>("HealthChecksUI:HealthCheckDatabaseConnectionString");

            services.AddHealthChecksUI()
                .AddSqliteStorage(sqliteConnectionString);

            //HealthChecks

            return services;
        }

        private static void PapertrailLoggerSetup(IConfiguration config, ILoggingBuilder loggingBuilder, WebApplicationBuilder? builder)
        {
            var papertrailConfig = config.GetSection("Papertrail");
            string papertrailHost = papertrailConfig["host"];
            int papertrailPort = Convert.ToInt32(papertrailConfig["port"]);

            if (builder.Environment.IsDevelopment())
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
