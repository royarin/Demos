using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;

namespace ProductAPI.GraphQL
{
    public class Query
    {
        public async Task<IEnumerable<Models.Product>> GetProducts(ProductContext context)
        {
            return await context.Products.ToListAsync();
        }
        public async Task<Models.Product> GetProduct(int id, ProductContext context)
        {
            return await context.Products.FindAsync(id);
        }

    }
}