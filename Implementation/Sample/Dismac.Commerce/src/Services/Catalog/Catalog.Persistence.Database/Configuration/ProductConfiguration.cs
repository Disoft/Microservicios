using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistence.Database.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.ProductId);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(500);

            var products = SeedData();

            entityBuilder.HasData(products);
        }

        private static List<Product> SeedData()
        {
            var products = new List<Product>();
            var random = new Random();

            for (int i = 1; i < 101; i++)
            {
                products.Add(new Product
                {
                    ProductId = i,
                    Name = $"Product {i}",
                    Description = $"Description in the product {i}",
                    Price = random.Next(100, 1000),
                });
            }

            return products;
        }
    }
}
