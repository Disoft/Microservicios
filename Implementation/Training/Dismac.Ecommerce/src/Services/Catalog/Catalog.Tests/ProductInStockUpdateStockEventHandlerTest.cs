using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.EventHandlers.DTOs;
using Catalog.Service.EventHandlers.Exceptions;
using Catalog.Tests.Configuration;
using Microsoft.Extensions.Logging;
//using Service.EventHandlers.Commands;
using Moq;
using static Catalog.Shared.Enums;

namespace Catalog.Tests
{
    [TestClass]
    public sealed class ProductInStockUpdateStockEventHandlerTest
    {
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

            Assert.AreEqual(context.Stocks.First(x => x.ProductId == productId).Stock, 2);
        }

        [TestMethod]
        public void TryToAddStockWhenProductExists()
        {
            var productInStockId = 3;
            var productId = 3;
            var currentStock = 1;

            int expectedResult = 3;

            CatalogDbContext context = PrepareDatabaseInMemoryData(productInStockId, productId, currentStock);

            List<ProductInStockUpdateItem> items = PrepareDataToSend(productId, 2, ProductInStockAction.Add);

            var handler = new ProductInStockUpdateStockEventHandler(context, GetLogger);

            handler.Handle(new ProductInStockUpdateStockCommand
            {
                Items = items
            }, new CancellationToken()).Wait();

            int actualResult = context.Stocks.First(x => x.ProductInStockId == productInStockId).Stock;

            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductInStockUpdateStockCommandException))]
        public void TryToSubstractStockWhenProductHasNotStock()
        {
            var productInStockId = 2;
            var productId = 2;
            var currentStock = 1;

            CatalogDbContext context = PrepareDatabaseInMemoryData(productInStockId, productId, currentStock);

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
        public void TryToSubstractStockWhenProductHasStock()
        {
            //Arrange
            var productId = 1;
            var productInStockId = 1;
            var expectedResult = 0;

            CatalogDbContext context = PrepareDatabaseInMemory(productId, productInStockId);

            var handler = new ProductInStockUpdateStockEventHandler(context, GetLogger);

            List<ProductInStockUpdateItem> items = PrepareDataToSend(productId, 1, ProductInStockAction.Substract);

            //Act
            handler.Handle(new ProductInStockUpdateStockCommand
            {
                Items = items,
            },
            new CancellationToken()).Wait();

            //Assert
            int actualResult = context.Stocks.Single(x => x.ProductId == productId).Stock;

            Assert.AreEqual(expectedResult, actualResult, "Stock insufficient!");
        }

        #region Helpers

        private ILogger<ProductInStockUpdateStockEventHandler> GetLogger
        {
            get
            {
                return new Mock<ILogger<ProductInStockUpdateStockEventHandler>>().Object;
            }
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

        private CatalogDbContext PrepareDatabaseInMemory(int productId, int productInStockId)
        {
            var context = ApplicationDbContextInMemory.Get();

            context.Stocks.Add(
                new Domain.ProductInStock
                {
                    ProductId = productId,
                    ProductInStockId = productInStockId,
                    Stock = 1
                });

            context.SaveChanges();

            return context;
        }

        private static CatalogDbContext PrepareDatabaseInMemoryData(int productInStockId, int productId, int currentStock)
        {
            var context = ApplicationDbContextInMemory.Get();

            context.Stocks.Add(
                    new Domain.ProductInStock
                    {
                        ProductId = productId,
                        ProductInStockId = productInStockId,
                        Stock = currentStock
                    });

            context.SaveChanges();
            return context;
        }

        #endregion
    }
}
