using AutoMapper;
using Customer.Api.Application.Interfaces;
using Customer.Api.Infrastructure.Persistence;
using MediatR;

namespace Customer.Api.Application.Features.Customers.Queries
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomersQuery, List<Domain.Customer>>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCustomerHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Domain.Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _repository.GetAllAsync();

            return _mapper.Map<List<Domain.Customer>>(customers);
        }
    }
}
