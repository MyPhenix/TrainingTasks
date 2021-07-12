using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Linq;

namespace AsyncAwait
{
    public interface IRepository<T>
    {
        Task<T> GetById(string id);
        Task Save(T item);
        Task Delete(string id);
    }

    public class MockProductsRepository : IRepository<Product>
    {
        private readonly ConcurrentDictionary<string, Product> _storage = new();

        public Task Delete(string id)
        {
            _storage.TryRemove(id, out _);
            return Task.CompletedTask;
        }

        public Task<Product> GetById(string id)
        {
            _storage.TryGetValue(id, out var value);
            return Task.FromResult(value);
        }

        public Task Save(Product item)
        {
            _storage.AddOrUpdate(item.Id, item, (key, value) => item);
            return Task.CompletedTask;
        }
    }

    // Task. Implement repository to use real database MsSql почитать  with Entity Framework почитать (Code First) почитать 

    public class ProductRepository : IRepository<Product>
    {
        private ProductsContext productsDB = new ProductsContext();
        public Task Delete(string id)
        {
            productsDB.Remove(productsDB.ToList().Where(x => x.Id == id));
            return Task.CompletedTask;
        }

        public Task<Product> GetById(string id)
        {
            return Task.FromResult(productsDB.ToList().First(x => x.Id == id));
        }

        public Task Save(Product item)
        {
            if (item != null)
            {
                productsDB.Add(item);                
            }
            return Task.CompletedTask;
        }
    }
}
