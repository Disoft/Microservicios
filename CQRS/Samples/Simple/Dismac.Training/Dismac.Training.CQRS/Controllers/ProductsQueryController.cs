using Dismac.Training.CQRS.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dismac.Training.CQRS.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsQueryController: ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsQueryController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return product is not null ? Ok(product) : NotFound();
        }
    }
}
