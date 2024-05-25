using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IDbContextFactory<ProductContext> _contextFactory;
        public ProductService(IDbContextFactory<ProductContext> contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }
        
        /// <summary>
        /// Retrieves a collection of products.
        /// </summary>
        /// <param name="page">The page number of the products to retrieve.</param>
        /// <param name="limit">The maximum number of products to retrieve per page.</param>
        /// <returns>A collection of products.</returns>
        public async Task<IEnumerable<Product>> GetProducts(int page = 1, int limit = 20)
        {
            Console.WriteLine("Get All Products");
            return await _contextFactory.CreateDbContext().Products.ToListAsync();
        }

        public async Task<Product> GetSingle(string sku)
        {
            Console.WriteLine("Get one Product");
            return await _contextFactory.CreateDbContext().Products.FindAsync(sku);
        }
    }
}