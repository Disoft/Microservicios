using Customer.Api.Application.Features.Customers.Commands;
using Customer.Api.Application.Features.Customers.Queries;
using Customer.Api.Application.Interfaces;
using Customer.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomerHandler).Assembly));
            //services.AddValidatorsFromAssembly(typeof(CrearClienteValidator).Assembly);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CustomerDbContext>(
                    opts =>
                    opts.UseSqlServer(
                            config.GetConnectionString("DefaultConnection"),
                            x => x.MigrationsHistoryTable("_EFMigrationHistory", "Customer")
                            )
                        );

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
