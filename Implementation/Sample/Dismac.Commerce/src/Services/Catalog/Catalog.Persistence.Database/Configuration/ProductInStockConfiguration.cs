using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistence.Database.Configuration
{
    public class ProductInStockConfiguration
    {
        public ProductInStockConfiguration(EntityTypeBuilder<ProductInStock> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ProductInStockId);
            List<ProductInStock> productsInStock = SeedData();

            entityBuilder.HasData(productsInStock);
        }

        private static List<ProductInStock> SeedData()
        {
            var productsInStock = new List<ProductInStock>();
            var random = new Random();

            for (int i = 1; i < 101; i++)
            {
                productsInStock.Add(new ProductInStock
                {
                    ProductInStockId = i,
                    ProductId = i,
                    Stock = random.Next(0, 20),
                });
            }

            return productsInStock;
        }
    }
}
