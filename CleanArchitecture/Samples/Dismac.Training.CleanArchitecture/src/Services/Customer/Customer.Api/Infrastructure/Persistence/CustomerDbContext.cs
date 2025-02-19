using NSCustomer = Customer.Api.Domain.Customer;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Infrastructure.Persistence
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        public DbSet<NSCustomer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Customer");

            CustomModelConfig(modelBuilder);
        }

        private void CustomModelConfig(ModelBuilder modelBuilder)
        {
            // Seed data for customers
            modelBuilder.Entity<NSCustomer>().HasData(
                new NSCustomer
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    CreatedDate = new DateTime(2025, 2, 17, 0, 0, 0, DateTimeKind.Utc)
                },
                new NSCustomer
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Jane Doe",
                    Email = "jane.doe@example.com",
                    CreatedDate = new DateTime(2025, 2, 17, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}
