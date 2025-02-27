using Catalog.Service.EventHandler.Commands;
using Catalog.Service.Queries;
using Catalog.Service.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Shared.Utils;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController(
        ILogger<ProductController> _logger,
        IProductQueryService _productQueryService,
        IMediator _mediator
        ) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id)
        {
            return await _productQueryService.GetAsync(id);
        }

        [HttpGet]
        public async Task<DataCollection<ProductDto>> GetAll(int page = 1, int pageSize = 10, string? ids = null)
        {
            IEnumerable<int>? products = null;

            if (!string.IsNullOrEmpty(ids))
            {
                products = ids?.Split(',').Select(i => int.Parse(i));
            }

            return await _productQueryService.GetAllAsync(page, pageSize, products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {
            await _mediator.Publish(command);

            return Created();
        }
    }
}
