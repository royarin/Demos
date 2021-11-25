using System.Threading.Tasks;
using HealthMarketWebClient.Data;

namespace HealthMarketWebClient.Services
{
    public interface ICartService
    {
         public Task AddToCart(Product product);
         public Task<Cart> GetCart();
         public Task ClearCart();
         public Task RemoveFromCart(Product product);
    }
}