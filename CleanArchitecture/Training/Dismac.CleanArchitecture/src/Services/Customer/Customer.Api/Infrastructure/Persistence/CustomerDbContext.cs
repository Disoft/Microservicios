using Customer.Api.Domain;
using Microsoft.EntityFrameworkCore;
using DCustomer = Customer.Api.Domain.Customer;

namespace Customer.Api.Infrastructure.Persistence
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        public DbSet<DCustomer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Customer");

            //modelBuilder.Entity<DCustomer>().HasIndex()
            //modelBuilder.Entity<DCustomer>().Property(x => x.Email).IsRequired().HasMaxLength(50);

            CustomModelConfig(modelBuilder);
        }

        private void CustomModelConfig(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<DCustomer>();

            entityBuilder.HasIndex(x => x.Id);
            entityBuilder.HasData(
                new DCustomer
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    CreatedDate = new DateTime(2025, 2, 17, 0, 0, 0, DateTimeKind.Utc)
                },
                new DCustomer
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
