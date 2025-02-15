using Dismac.Training.CQRS.Services.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dismac.Training.CQRS.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsCommandController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsCommandController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var product = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateProduct), new { id = product.Id }, product);
        }
    }
}
