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
   
    internal class ProductCreateEventHandler: INotificationHandler<ProductCreateCommand>
    {
        private readonly ApplicationDbContext _context;

        public ProductCreateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ProductCreateCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Product
            {
                Name = notification.Name,
                Description = notification.Description,
                Price = notification.Price
            });

            await _context.SaveChangesAsync();
        }
    }
}
