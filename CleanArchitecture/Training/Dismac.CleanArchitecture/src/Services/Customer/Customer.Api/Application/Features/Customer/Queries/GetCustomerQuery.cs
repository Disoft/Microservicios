using MediatR;

namespace Customer.Api.Application.Features.Customer.Queries
{
   public record GetCustomerQuery(Guid id): IRequest<Domain.Customer?>;
}
