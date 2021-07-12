using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IRepository<Product> repository = new MockProductsRepository();
            // add 3 elements
            var products = new List<Product>
            {
                new Product { Id = "1", Name = "Apple" },
                new Product { Id = "2", Name = "Pen" },
                new Product { Id = "3", Name = "Pineapple" }
            };

            var saveTasks = products.Select(x => repository.Save(x));
            await Task.WhenAll(saveTasks).ConfigureAwait(false);

            // get by id first element
            var product = await repository.GetById("1");
            PrintProduct(product);
            // remove first element
            await repository.Delete("1");
            // get by id first element (should be null)
            product = await repository.GetById("1");
            PrintProduct(product);
        }

        private static void PrintProduct(Product product)
        {
            if (product is null)
            {
                Console.WriteLine("Product is null");
                return;
            }

            Console.WriteLine($"Product {product.Id}: {product.Name}");
        }
    }

    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
