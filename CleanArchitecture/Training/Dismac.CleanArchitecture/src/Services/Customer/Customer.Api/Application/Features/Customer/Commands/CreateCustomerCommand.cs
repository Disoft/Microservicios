using MediatR;

namespace Customer.Api.Application.Features.Customer.Commands
{
    public record CreateCustomerCommand(string Name, string Email): IRequest<Guid>;
   
}
