using MediatR;
using NSCustomer = Customer.Api.Domain.Customer;

namespace Customer.Api.Application.Features.Customers.Queries
{
    public record GetCustomerQuery(Guid Id) : IRequest<NSCustomer?>;
}
