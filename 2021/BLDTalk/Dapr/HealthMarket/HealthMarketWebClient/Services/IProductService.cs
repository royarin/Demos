using System.Collections.Generic;
using System.Threading.Tasks;
using HealthMarketWebClient.Data;

namespace HealthMarketWebClient.Services
{
    public interface IProductService
    {
         public Task<IEnumerable<Product>> GetProducts();
    }
}