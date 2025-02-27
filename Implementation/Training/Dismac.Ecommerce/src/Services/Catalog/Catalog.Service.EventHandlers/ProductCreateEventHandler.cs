using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandler.Commands;
using MediatR;

namespace Catalog.Service.EventHandler
{
    public class ProductCreateEventHandler(CatalogDbContext _context) : INotificationHandler<ProductCreateCommand>
    {
        public async Task Handle(ProductCreateCommand command, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(
                new Product
                {
                    Name = command.Name,
                    Description = command.Description,
                    Price = command.Price
                });

            await _context.SaveChangesAsync();
        }
    }
}
