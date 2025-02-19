using MediatR;

namespace Customer.Api.Application.Features.Customers.Queries
{
    public record GetCustomerQuery(Guid Id) : IRequest<Domain.Customer?>;
}
