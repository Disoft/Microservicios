using Dismac.Training.CQRS.Model;
using MediatR;

namespace Dismac.Training.CQRS.Services.Commands
{
    public record CreateProductCommand(string Name, decimal Price) : IRequest<Product>;

    public class ProductEventHandler: IRequestHandler<CreateProductCommand, Product>
    {
        private static readonly List<Product> Products = new();

        public Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product { Id = Products.Count + 1, Name = request.Name, Price = request.Price };
            Products.Add(product);
            return Task.FromResult(product);
        }
    }
}
