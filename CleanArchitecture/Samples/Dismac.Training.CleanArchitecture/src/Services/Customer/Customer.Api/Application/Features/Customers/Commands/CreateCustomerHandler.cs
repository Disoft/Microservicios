using Customer.Api.Application.Interfaces;
using MediatR;
using NSCustomer = Customer.Api.Domain.Customer;

namespace Customer.Api.Application.Features.Customers.Commands
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new NSCustomer(request.Name, request.Email);
            await _repository.CreateAsync(customer);
            return customer.Id;
        }
    }
}
