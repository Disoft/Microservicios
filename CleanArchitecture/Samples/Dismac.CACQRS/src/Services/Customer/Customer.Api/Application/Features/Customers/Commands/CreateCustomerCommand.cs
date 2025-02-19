using MediatR;

namespace Customer.Api.Application.Features.Customers.Commands
{
    public record CreateCustomerCommand(string Name, string Email): IRequest<Guid>;
}
