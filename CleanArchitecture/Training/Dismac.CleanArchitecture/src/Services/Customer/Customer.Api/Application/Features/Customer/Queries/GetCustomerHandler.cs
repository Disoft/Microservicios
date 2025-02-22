using Customer.Api.Application.Interfaces;
using MediatR;

namespace Customer.Api.Application.Features.Customer.Queries
{
    public class GetCustomerHandler(ICustomerRepository _customerRepository) : IRequestHandler<GetCustomerQuery, Domain.Customer?>
    {
        public async Task<Domain.Customer?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetByIdAsync(request.id);
        }
    }
}
