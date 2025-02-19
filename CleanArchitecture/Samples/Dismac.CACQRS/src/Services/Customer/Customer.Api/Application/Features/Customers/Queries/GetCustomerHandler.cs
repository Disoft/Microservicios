using Customer.Api.Application.Interfaces;
using MediatR;

namespace Customer.Api.Application.Features.Customers.Queries
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, Domain.Customer?>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Customer?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
