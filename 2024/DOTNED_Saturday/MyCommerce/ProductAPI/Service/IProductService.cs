using ProductAPI.Models;

namespace ProductAPI.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts(int page, int limit);
        Task<Product> GetSingle(string id);
    }
}