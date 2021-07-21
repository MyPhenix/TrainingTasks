using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace AsyncAwait
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> _products { get; set; }

        public ProductsContext()
        {
            Database.EnsureCreated();            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True");
        }
    }
}
