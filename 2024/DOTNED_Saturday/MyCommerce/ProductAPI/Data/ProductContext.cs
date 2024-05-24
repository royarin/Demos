using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Data
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {
        }

        public DbSet<ProductAPI.Models.Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductAPI.Models.Product>()
                .HasIndex(x => x.SKU)
                .IsUnique();
        }
    }
}
