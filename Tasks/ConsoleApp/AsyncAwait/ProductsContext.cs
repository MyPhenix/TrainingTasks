using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace AsyncAwait
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> _products { get; set; }

        private string _connectionString { get; set; }

        public ProductsContext(string connectionString = @"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True")
        {
            Database.EnsureCreated();
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True");
        }
    }
}
