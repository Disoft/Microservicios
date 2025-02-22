using Customer.Api.Application.Interfaces;
using MediatR;

namespace Customer.Api.Application.Features.Customer.Commands
{
    public class CreateCustomerHandler(ICustomerRepository _customerRepository) : IRequestHandler<CreateCustomerCommand, Guid>
    {
        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Domain.Customer(request.Name, request.Email);

            await _customerRepository.CreateAsync(customer);

            return customer.Id;
        }
    }
}
