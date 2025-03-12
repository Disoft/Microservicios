using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Order.Service.Proxies;
using Order.Service.Proxy.Catalog.Commands;
using System.Text;
using System.Text.Json;

namespace Order.Service.Proxy.Catalog
{
    public class CatalogHttpProxy(
        IOptions<ApiUrls> _apiUrls,
        HttpClient _httpClient
        ,IHttpContextAccessor _httpContextAccessor
        ) : ICatalogProxy
    {
        public async Task UpdateStockAsync(ProductInStockUpdateStockCommand command)
        {
            _httpClient.AddBearerToken(_httpContextAccessor);

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
