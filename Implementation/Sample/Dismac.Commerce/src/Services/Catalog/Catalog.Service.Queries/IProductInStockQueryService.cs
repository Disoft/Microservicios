using Catalog.Service.Queries.DTOs;
using Service.Common.Utils;

namespace Catalog.Service.Queries
{
    public interface IProductInStockQueryService
    {
        Task<DataCollection<ProductInStockDto>> GetAllAsync(int page, int take, IEnumerable<int> products = null);
    }
}
