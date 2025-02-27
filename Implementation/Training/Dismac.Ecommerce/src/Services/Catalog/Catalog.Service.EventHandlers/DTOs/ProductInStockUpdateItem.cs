using static Catalog.Shared.Enums;

namespace Catalog.Service.EventHandlers.DTOs
{
    public class ProductInStockUpdateItem
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public ProductInStockAction Action { get; set; }
    }
}
