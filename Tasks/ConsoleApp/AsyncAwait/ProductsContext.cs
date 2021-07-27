using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace AsyncAwait
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}