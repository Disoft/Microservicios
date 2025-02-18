using Catalog.Service.Queries;
using Catalog.Services.Queries.DTOs;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Utils;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController(IProductQueryService productQueryService): ControllerBase
    {
        [HttpGet]
        public async Task<DataCollection<ProductDto>> GetAll(int page = 11, int pageSize = 10, string ids = null)
        {
            IEnumerable<int>? products = null;
            
            products = ids?.Split(',').Select(i => int.Parse(i));

            return await productQueryService.GetAllAsync(page, pageSize, products);
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id)
        {
            return await productQueryService.GetAsync(id);
        }
    }
}
