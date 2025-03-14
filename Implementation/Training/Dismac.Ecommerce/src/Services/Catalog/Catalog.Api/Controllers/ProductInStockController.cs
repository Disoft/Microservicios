using Catalog.Service.EventHandler.Commands;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.Queries;
using Catalog.Service.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Shared.Utils;

namespace Catalog.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("v1/stocks")]
    public class ProductInStockController(
        ILogger<ProductInStockController> _logger,
        IProductInStockQueryService _productInStockQueryService,
        IMediator _mediator
        ) : ControllerBase
    {

        [HttpGet]
        public async Task<DataCollection<ProductInStockDto>> GetAll(int page = 1, int pageSize = 10, string? ids = null)
        {
            IEnumerable<int>? products = null;

            if (!string.IsNullOrEmpty(ids))
            {
                products = ids?.Split(',').Select(i => int.Parse(i));
            }

            return await _productInStockQueryService.GetAllAsync(page, pageSize, products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductInStockUpdateStockCommand command)
        {
            await _mediator.Publish(command);

            return NoContent();
        }
    }
}
