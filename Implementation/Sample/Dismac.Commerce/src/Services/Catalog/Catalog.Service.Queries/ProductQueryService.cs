using Catalog.Persistence.Database;
using Catalog.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Utils;

namespace Catalog.Service.Queries
{
    public class ProductQueryService(ApplicationDbContext _context) : IProductQueryService
    {
        public async Task<DataCollection<ProductDto>> GetAllAsync(int page, int take, IEnumerable<int>? products = null)
        {
            var collection = await 
                _context.Products
                .Where(x => products == null || products.Contains(x.ProductId))
                .OrderBy(x => x.Name)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ProductDto>>();
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            return (await _context.Products.SingleAsync(x => x.ProductId == id)).MapTo<ProductDto>();
        }

    }
}
