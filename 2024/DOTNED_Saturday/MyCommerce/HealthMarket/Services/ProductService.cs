using HealthMarket.Data;

namespace HealthMarket.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient = null!;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ProductAPI");
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("products");
            return result ?? Enumerable.Empty<Product>();
        }
    }
}
