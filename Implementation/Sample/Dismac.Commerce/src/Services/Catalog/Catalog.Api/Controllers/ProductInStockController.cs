using Catalog.Service.EventHandler.Commands;
using Catalog.Service.Queries;
using Catalog.Service.Queries.DTOs;
using MediatR;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
using Service.Common.Utils;

namespace Catalog.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("v1/stocks")]
    public class ProductInStockController(
            ILogger<ProductInStockController> _logger,
            IMediator _mediator,
            IProductInStockQueryService _productInStockQueryService) : ControllerBase
    {
        [HttpGet]
        public async Task<DataCollection<ProductInStockDto>> GetAll(int page = 1, int take = 10, string products = null)
        {
            IEnumerable<int> ids = null;

            if (!string.IsNullOrEmpty(products))
            {
                ids = products.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _productInStockQueryService.GetAllAsync(page, take, ids);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStock(ProductInStockUpdateStockCommand command)
        {
            await _mediator.Publish(command);
            return NoContent();
        }
    }
}
