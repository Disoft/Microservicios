using Customer.Api.Application.Features.Customers.Commands;
using Customer.Api.Application.Features.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Presentation
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        //private readonly IMessagePublisher _messagePublisher;

        //public CustomerController(IMediator mediator, IMessagePublisher messagePublisher)
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
            // _messagePublisher = messagePublisher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCustomer), new { id }, id);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreatedEvent customer)
        //{
        //    _messagePublisher.Publish(customer);
        //    return Ok(new { Message = "Customer event published", customer });
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomerQuery(id));
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customer = await _mediator.Send(new GetAllCustomersQuery());
            if (customer == null) return NotFound();
            return Ok(customer);
        }
    }
}
