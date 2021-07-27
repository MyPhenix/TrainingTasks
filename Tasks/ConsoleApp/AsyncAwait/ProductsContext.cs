using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace AsyncAwait
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> _products { get; set; }

        private string _connectionString { get; set; }

        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}