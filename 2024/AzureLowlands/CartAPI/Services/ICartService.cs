using CartAPI.Models;

namespace CartAPI.Services
{
    public interface ICartService
    {
        Task AddToCart(Product product);
        Task<Cart> GetCart();
        Task ClearCart();
        Task RemoveFromCart(LineItem lineItem);
    }
}