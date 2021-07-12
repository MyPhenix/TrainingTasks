using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {

            var products = new List<Product>
            {
                new Product("1", "apple", 100, null),
                new Product("2", "potato", 150, null),
                new Product("3", "cucumber", 200, null),
                new Product("4", "carrot", 250, null),
            };

            var processedProducts = FilterProductsByPrice(products, 120, 220);
            Print(processedProducts);

            processedProducts = FilterProductsByPrice(products, 120, -1);
            Print(processedProducts);

            5.IsEven();

            Console.ReadKey();
        }

        private static void Print(IEnumerable<IPrintable> objects)
        {
            Console.WriteLine("Print start ===================");
            foreach (var obj in objects)
            {
                Console.WriteLine(obj.GetInfo());
            }
            Console.WriteLine("Print end =====================");
        }

        //if -1 do not include in comparison
        // if from is bigger than to than throw exception

        private static IEnumerable<Product> FilterProductsByPrice(IEnumerable<Product> products, decimal from, decimal to)
        {
            if (from >= to && to > -1)
                throw new ArgumentException(nameof(to));

            Func<string, bool> isNullOrEmptyFunc = (s) => string.IsNullOrEmpty(s);

            Console.WriteLine("123");
            Action<Product> printProduct = p => Console.WriteLine(p.GetInfo());
            
                
            
            return products.Where(x => x.Price >= from && (to <= -1 || x.Price <= to));

        }
    }

    public class Product : IPrintable
    {
        public Product(string id, string name, decimal price, IEnumerable<Category> categories)
        {
            Id = id;
            Name = name;
            Price = price;
            Categories = categories;
        }

        public string Id { get; set; }
        public string Name { get;  set; }
        public decimal Price { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public string GetInfo()
        {
            var result = new StringBuilder($"<Product> Id: {Id}, Name: {Name}, Price: {Price}");

            if (Categories?.Any() == true)
            {
                result.Append($"Categories: { string.Join(", ", Categories?.Select(x => x.Name))}");
            }

            return result.ToString();
        }
    }

    public class Category : IPrintable
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string GetInfo()
        {
            return $"<Category> Id: {Id}, Name: {Name}";
        }
    }

    public interface IPrintable
    {
        string GetInfo();
    }

    public static class IntExtensions
    {
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }
    }
}
