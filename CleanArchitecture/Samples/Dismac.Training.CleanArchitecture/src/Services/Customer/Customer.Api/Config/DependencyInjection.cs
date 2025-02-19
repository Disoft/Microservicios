using Customer.Api.Application.Features.Customers.Commands;
using Customer.Api.Application.Interfaces;
using Customer.Api.Application.Validators;
using Customer.Api.Infrastructure.Persistence;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;


namespace Customer.Api.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomerHandler).Assembly));
            services.AddValidatorsFromAssembly(typeof(CreateCustomerValidator).Assembly);
            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CustomerDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
