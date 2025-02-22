using Customer.Api.Application.Features.Customer.Commands;
using Customer.Api.Application.Interfaces;
using Customer.Api.Application.Validators;
using Customer.Api.Infrastructure.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services )
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomerHandler).Assembly));

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerDbContext>(
                    opts =>
                    opts.UseSqlServer(
                            configuration.GetConnectionString("DefaultConnection"),
                            x => x.MigrationsHistoryTable("_EFMigrationHistory", "Customer")
                            )
                        );

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddValidatorsFromAssembly(typeof(CreateCustomerValidator).Assembly);

            return services;
        }
    }
}
