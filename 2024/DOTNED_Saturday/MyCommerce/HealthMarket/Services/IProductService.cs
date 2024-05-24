using HealthMarket.Data;

namespace HealthMarket.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProducts();
    }
}
