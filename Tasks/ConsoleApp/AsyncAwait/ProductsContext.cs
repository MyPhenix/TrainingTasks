using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace AsyncAwait
{
    class ProductsContext : DbContext
    {
        private DbSet<Product> _products;

        public ProductsContext()
        {
            Database.EnsureCreated();            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True");
        }

        public IEnumerable<Product> ToList()
        {
            return _products.ToList();
        }
    }
}
