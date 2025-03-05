using Microsoft.Extensions.Options;
using Order.Service.Proxy.Catalog.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Order.Service.Proxy.Catalog
{
    public class CatalogHttpProxy(IOptions<ApiUrls> _apiUrls, HttpClient _httpClient): ICatalogProxy
    {
        public async Task UpdateStockAsync(ProductInStockUpdateStockCommand command) 
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PutAsync(_apiUrls.Value.CatalogUrl + "v1/stocks", content);

            request.EnsureSuccessStatusCode();
        }
    }
}
