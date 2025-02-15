using Dismac.Training.CQRS.Model;
using MediatR;

namespace Dismac.Training.CQRS.Services.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;

    public class ProductQueryService : IRequestHandler<GetProductByIdQuery, Product>
    {
        private static readonly List<Product> Products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200 },
            new Product { Id = 2, Name = "Mouse", Price = 25 }
        };

        public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = Products.FirstOrDefault(p => p.Id == request.Id);
            return Task.FromResult(product);
        }
    }
}
