using System;
using System.Net.Http;
using System.Threading.Tasks;
using Dapr.Client;
using HealthMarketWebClient.Data;

namespace HealthMarketWebClient.Services
{
    public class CartService : ICartService
    {
        private DaprClient _daprClient;

        public delegate void CartHasChanged();
        public event CartHasChanged CartHasChangedEvent;
        public CartService(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        public async Task AddToCart(Product product)
        {
            await _daprClient.InvokeMethodAsync("cart-api", "cart/add", product);
            FireCartHasChanged();
        }

        public async Task<Cart> GetCart(){
            return await _daprClient.InvokeMethodAsync<Cart>(HttpMethod.Get,"cart-api","cart");
        }

        public async Task RemoveFromCart(Product product)
        {
            await _daprClient.InvokeMethodAsync("cart-api","cart/remove",product);
            FireCartHasChanged();
        }

        public async Task ClearCart()
        {
            await _daprClient.InvokeMethodAsync(HttpMethod.Post,"cart-api","cart/clear");
            FireCartHasChanged();
        }

        private void FireCartHasChanged()
        {
            if (CartHasChangedEvent != null)
                CartHasChangedEvent();
        }
    }
}