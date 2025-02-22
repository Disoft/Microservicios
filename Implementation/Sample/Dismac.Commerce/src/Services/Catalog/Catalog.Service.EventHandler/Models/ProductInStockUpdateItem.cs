using static Catalog.Common.Enums;

namespace Catalog.Service.EventHandler.Models
{
    public class ProductInStockUpdateItem
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public ProductInStockAction Action { get; set; }
    }
}
