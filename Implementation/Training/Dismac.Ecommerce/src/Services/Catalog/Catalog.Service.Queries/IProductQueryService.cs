using Catalog.Service.Queries.DTOs;
using Service.Shared.Utils;

namespace Catalog.Service.Queries
{
    public interface IProductQueryService
    {
        Task<DataCollection<ProductDto>> GetAllAsync(int page, int take, IEnumerable<int> products = null);

        Task<ProductDto> GetAsync(int id);
    }
}
