using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandler.Commands;
using Catalog.Service.EventHandler.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Catalog.Common.Enums;

namespace Catalog.Service.EventHandlers
{
    public class ProductInStockUpdateStockEventHandler(
        ApplicationDbContext _context,
        ILogger<ProductInStockUpdateStockEventHandler> _logger) :
        INotificationHandler<ProductInStockUpdateStockCommand>
    {
        public async Task Handle(ProductInStockUpdateStockCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- ProductInStockUpdateStockCommand started");

            var products = notification.Items.Select(x => x.ProductId);
            var stocks = await _context.ProductsInStock.Where(x => products.Contains(x.ProductId)).ToListAsync();

            _logger.LogInformation("--- Retrieve products from database");

            foreach (var item in notification.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);

                if (item.Action == ProductInStockAction.Substract)
                {
                    if (entry == null || item.Stock > entry.Stock)
                    {
                        _logger.LogError($"--- Product {entry.ProductId} - doesn't have enough stock");
                        throw new ProductInStockUpdateStockCommandException($"Product {entry.ProductId} - doesn't have enough stock");
                    }

                    entry.Stock -= item.Stock;

                    _logger.LogInformation($"--- Product {entry.ProductId} - its stock was subtracted and its new stock is {entry.Stock}");
                }
                else
                {
                    if (entry == null)
                    {
                        entry = new ProductInStock
                        {
                            ProductId = item.ProductId
                        };

                        _logger.LogInformation($"--- New stock record was created for {entry.ProductId} because didn't exists before");

                        await _context.AddAsync(entry);
                    }

                    _logger.LogInformation($"--- Add stock to product {entry.ProductId}");
                    entry.Stock += item.Stock;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
