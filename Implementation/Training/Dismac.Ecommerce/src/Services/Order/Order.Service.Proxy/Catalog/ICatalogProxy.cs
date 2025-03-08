using Order.Service.Proxy.Catalog.Commands;

namespace Order.Service.Proxy.Catalog
{
    public interface ICatalogProxy
    {
        Task UpdateStockAsync(ProductInStockUpdateStockCommand command);
    }
}
