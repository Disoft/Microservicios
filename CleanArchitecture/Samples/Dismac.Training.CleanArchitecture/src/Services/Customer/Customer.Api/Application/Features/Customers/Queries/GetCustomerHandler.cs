using Customer.Api.Application.Interfaces;
using MediatR;
using NSCustomer = Customer.Api.Domain.Customer;

namespace Customer.Api.Application.Features.Customers.Queries
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, NSCustomer?>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<NSCustomer?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }

    }
}
