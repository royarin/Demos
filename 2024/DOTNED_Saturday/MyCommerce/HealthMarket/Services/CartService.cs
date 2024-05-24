using HealthMarket.Data;
using System.Net;
using System.Text.Json;

namespace HealthMarket.Services
{
    public class CartService : ICartService
    {
        public event Action OnChange;
        private readonly HttpClient _httpClient = null!;

        public CartService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("CartAPI");
        }

        public async Task AddToCart(Product product)
        {
            await _httpClient.PostAsJsonAsync("cart/add", product);
            OnChange?.Invoke();
        }

        public async Task<Cart> GetCart()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Cart>("cart");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task ClearCart()
        {
            await _httpClient.PostAsJsonAsync("cart/clear", new Product());
            OnChange?.Invoke();
        }

        public async Task RemoveFromCart(LineItem lineItem)
        {
            await _httpClient.PostAsJsonAsync("cart/remove", lineItem);
            OnChange?.Invoke();
        }
    }
}
