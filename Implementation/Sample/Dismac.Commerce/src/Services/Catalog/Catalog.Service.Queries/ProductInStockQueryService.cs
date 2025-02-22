using Catalog.Persistence.Database;
using Catalog.Service.Queries.DTOs;
using Service.Common.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Service.Queries
{
    public class ProductInStockQueryService(ApplicationDbContext _context) : IProductInStockQueryService
    {
        public async Task<DataCollection<ProductInStockDto>> GetAllAsync(int page, int take, IEnumerable<int> products = null)
        {
            var collection = await _context.ProductsInStock
                .Where(x => products == null || products.Contains(x.ProductId))
                .OrderBy(x => x.ProductId)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ProductInStockDto>>();
        }
    }
}
