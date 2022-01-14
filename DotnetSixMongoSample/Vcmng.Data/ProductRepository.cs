using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vcmng.Data.Abstractions;
using Vcmng.Infrastructure.Models;
using Vcmng.Infrastructure.Settings;

namespace Vcmng.Data
{
    public class ProductRepository : IProductRepository
    {
        IMongoCollection<Product> _products;

        public ProductRepository(
            IMongoDbClient mongoClient,
            IMongoDbSetting settings
            )
        {
            _products = mongoClient.Database.GetCollection<Product>(settings.ProductCollectionName);
        }

        public async Task<Product> GetAsync(string id)
        {
            var result = await _products.FindAsync(t => t.Id == id);
            return result.FirstOrDefault();
        }

        public async Task<List<Product>> GetAsync()
        {
            var result = await _products.FindAsync(t => true);
            return result.ToList();
        }

        public async Task<Product> InsertAsync(Product product)
        {
            await _products.InsertOneAsync(product);
            return product;
        }

        public async Task RemoveAsync(string id)
        {
            await _products.DeleteOneAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(string id, Product product)
        {
            await _products.ReplaceOneAsync(t => t.Id == id, product);
        }
    }
}
