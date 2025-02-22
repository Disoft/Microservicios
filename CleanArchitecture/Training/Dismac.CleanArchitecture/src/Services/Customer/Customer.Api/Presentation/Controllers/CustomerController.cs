using Customer.Api.Application.Features.Customer.Commands;
using Customer.Api.Application.Features.Customer.Queries;
using Customer.Api.Application.Features.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Presentation.Controllers
{
    [ApiController]
    [Route("v1/customers")]
    public class CustomerController(
        ILogger<CustomerController> _logger,
        IMediator _mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            GetCustomerQuery customerDto = new GetCustomerQuery(id);

            var customer = await _mediator.Send(customerDto);

            if (customer == null)  return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command) 
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCustomer), new { id }, id);
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
