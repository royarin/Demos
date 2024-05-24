using HealthMarket.Data;

namespace HealthMarket.Services
{
    public interface ICartService
    {
        public event Action OnChange;
        public Task AddToCart(Product product);
        public Task<Cart> GetCart();
        public Task ClearCart();
        public Task RemoveFromCart(LineItem lineItem);
    }
}
