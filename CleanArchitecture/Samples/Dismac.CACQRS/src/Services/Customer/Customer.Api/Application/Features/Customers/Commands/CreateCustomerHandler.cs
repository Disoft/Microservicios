using Customer.Api.Application.Interfaces;
using MediatR;

namespace Customer.Api.Application.Features.Customers.Commands
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Domain.Customer(request.Name, request.Email);
            await _customerRepository.CreateAsync(customer);

            return customer.Id;
        }
    }
}
