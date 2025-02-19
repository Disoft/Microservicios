using MediatR;

namespace Customer.Api.Application.Features.Customers.Queries
{
    public record GetAllCustomersQuery: IRequest<List<Domain.Customer>>;
}
