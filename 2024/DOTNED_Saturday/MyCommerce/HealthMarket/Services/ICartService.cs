using HealthMarket.Data;

namespace HealthMarket.Services
{
    public interface ICartService
    {
        public Task AddToCart(Product product);
        public Task<Cart> GetCart();
        public Task ClearCart();
    }
}
