using Catalog.Service.EventHandler.Models;
using MediatR;
using System.Collections.Generic;
using static Catalog.Common.Enums;

namespace Catalog.Service.EventHandler.Commands
{
    public class ProductInStockUpdateStockCommand : INotification
    {
        public IEnumerable<ProductInStockUpdateItem> Items { get; set; } = new List<ProductInStockUpdateItem>();
    }
}
