﻿using Customer.Api.Application.Interfaces;
using MediatR;
using NSCustomer = Customer.Api.Domain.Customer;

namespace Customer.Api.Application.Features.Customers.Queries
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<NSCustomer>>
    {
        private readonly ICustomerRepository _repository;

        public GetAllCustomersHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<NSCustomer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
