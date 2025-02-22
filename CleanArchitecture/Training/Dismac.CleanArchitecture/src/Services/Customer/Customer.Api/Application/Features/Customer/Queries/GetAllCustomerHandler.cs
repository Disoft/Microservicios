using AutoMapper;
using Customer.Api.Application.Interfaces;
using Customer.Api.Infrastructure.Persistence;
using MediatR;

namespace Customer.Api.Application.Features.Customers.Queries
{
    public class GetAllCustomerHandler(
        ICustomerRepository _repository,
        IMapper _mapper) : IRequestHandler<GetAllCustomersQuery, List<Domain.Customer>>
    {
        public async Task<List<Domain.Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _repository.GetAllAsync();

            return _mapper.Map<List<Domain.Customer>>(customers);
        }
    }
}
