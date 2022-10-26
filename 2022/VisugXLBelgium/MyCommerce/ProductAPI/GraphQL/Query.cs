using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;

namespace ProductAPI.GraphQL
{
    public class Query
    {
        public IQueryable<Models.Product> GetProducts(ProductContext context)
        {
            return context.Products;
        }
        public async Task<Models.Product> GetProduct(int id, ProductContext context)
        {
            return await context.Products.FindAsync(id);
        }
    }
}