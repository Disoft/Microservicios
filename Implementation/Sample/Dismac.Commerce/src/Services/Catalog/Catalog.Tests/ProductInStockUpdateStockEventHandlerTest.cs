using Castle.Core.Logging;
using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandler.Commands;
using Catalog.Service.EventHandler.Exceptions;
using Catalog.Service.EventHandler.Models;
using Catalog.Service.EventHandlers;
using Catalog.Tests.Config;
using Microsoft.Extensions.Logging;
using Moq;
using static Catalog.Common.Enums;

namespace Catalog.Tests
{
    [TestClass]
    public sealed class ProductInStockUpdateStockEventHandlerTest
    {
        private ILogger<ProductInStockUpdateStockEventHandler> GetLogger
        {
            get
            {
                return new Mock<ILogger<ProductInStockUpdateStockEventHandler>>().Object;
            }
        }

        [TestMethod]
        public void TryToSubstractStockWhenProductHasStock()
        {
            var productInStockId = 1;
            var productId = 1;
            var currentStock = 1;

            ApplicationDbContext context = PrepareDatabaseInMemoryData(productInStockId, productId, currentStock);

            List<ProductInStockUpdateItem> items = PrepareDataToSend(productId, 1, ProductInStockAction.Substract);

            var handler = new ProductInStockUpdateStockEventHandler(context, GetLogger);

            handler.Handle(new ProductInStockUpdateStockCommand
            {
                Items = items
            }, new CancellationToken()).Wait();

        }

        [TestMethod]
        [ExpectedException(typeof(ProductInStockUpdateStockCommandException))]
        public void TryToSubstractStockWhenProductHasNotStock()
        {
            var productInStockId = 2;
            var productId = 2;
            var currentStock = 1;

            ApplicationDbContext context = PrepareDatabaseInMemoryData(productInStockId, productId, currentStock);

            List<ProductInStockUpdateItem> items = PrepareDataToSend(productId, 2, ProductInStockAction.Substract);

            var handler = new ProductInStockUpdateStockEventHandler(context, GetLogger);

            try
            {
                handler.Handle(new ProductInStockUpdateStockCommand
                {
                    Items = items
                }, new CancellationToken()).Wait();
            }
            catch (AggregateException ae)
            {

                var exception = ae.GetBaseException();

                if (exception is ProductInStockUpdateStockCommandException)
                {
                    throw new ProductInStockUpdateStockCommandException(exception?.InnerException?.Message);

                }
            }
        }

        [TestMethod]
        public void TryToAddStockWhenProductExists()
        {
            var productInStockId = 3;
            var productId = 3;
            var currentStock = 1;

            ApplicationDbContext context = PrepareDatabaseInMemoryData(productInStockId, productId, currentStock);

            List<ProductInStockUpdateItem> items = PrepareDataToSend(productId, 2, ProductInStockAction.Add);

            var handler = new ProductInStockUpdateStockEventHandler(context, GetLogger);

            handler.Handle(new ProductInStockUpdateStockCommand
            {
                Items = items
            }, new CancellationToken()).Wait();

            Assert.AreEqual(context.ProductsInStock.First(x => x.ProductInStockId == productInStockId).Stock, 3);
        }

        [TestMethod]
        public void TryToAddStockWhenProductNotExists()
        {
            var context = ApplicationDbContextInMemory.Get();
            var command = new ProductInStockUpdateStockEventHandler(context, GetLogger);

            var productId = 4;

            List<ProductInStockUpdateItem> items = PrepareDataToSend(productId, 2, ProductInStockAction.Add);

            command.Handle(new ProductInStockUpdateStockCommand
            {
                Items = items
            }, new System.Threading.CancellationToken()).Wait();

            Assert.AreEqual(context.ProductsInStock.First(x => x.ProductId == productId).Stock, 2);
        }

        private static List<ProductInStockUpdateItem> PrepareDataToSend(int productId, int stockToWork, ProductInStockAction action)
        {
            return new List<ProductInStockUpdateItem>() {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = stockToWork,
                        Action = action
                    }
                };
        }

        private static ApplicationDbContext PrepareDatabaseInMemoryData(int productInStockId, int productId, int currentStock)
        {
            var context = ApplicationDbContextInMemory.Get();

            context.ProductsInStock.Add(
                    new Domain.ProductInStock
                    {
                        ProductId = productId,
                        ProductInStockId = productInStockId,
                        Stock = currentStock
                    });

            context.SaveChanges();
            return context;
        }
    }
}
