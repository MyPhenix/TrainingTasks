using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

    public class ProductRepository : IRepository<Product>, IDisposable
    {
        public ProductsContext _context { get; set; }

        private bool _disposed = false;

        public ProductRepository(ProductsContext conext)
        {
            _context = conext;
        }

        public async Task Delete(string id)
        {
            _context._products.Remove(await GetById(id));
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetById (string id)
        {
            return await _context._products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Save(Product item)
        {
            if (item is null)
            {
                return;
            }

            await _context._products.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            //_context?.Dispose();
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _context?.Dispose();
            }

            _disposed = true;
        }
    }
}
