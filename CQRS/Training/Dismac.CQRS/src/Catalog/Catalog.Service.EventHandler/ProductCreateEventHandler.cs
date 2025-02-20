using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandler.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Service.EventHandler
{
    public class ProductCreateEventHandler(ApplicationDbContext _context): INotificationHandler<ProductCreateCommand>
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
