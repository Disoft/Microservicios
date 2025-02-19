using Customer.Api.Application.Features.Customers.Commands;
using Customer.Api.Application.Features.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Presentation
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCustomer), new { id }, id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomerQuery(id));
            if (customer == null) return NotFound();

            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customer = await _mediator.Send(new GetAllCustomersQuery());
            if (customer == null) return NotFound();

            return Ok(customer);
        }
    }
}
