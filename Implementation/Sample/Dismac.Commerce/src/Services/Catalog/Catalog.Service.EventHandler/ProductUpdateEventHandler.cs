using Azure.Core;
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
    public class ProductUpdateEventHandler(ApplicationDbContext _context): IRequestHandler<ProductUpdateCommand, bool>
    {
        public async Task<bool> Handle(ProductUpdateCommand command, CancellationToken cancellationToken) 
        {
            var product = await _context.Products.FindAsync(command.Id);

            if (product == null)
            { 
                return false;
            }

            product.Name = command.Name;
            product.Description = command.Description;
            product.Price = command.Price;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
