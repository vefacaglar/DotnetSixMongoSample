using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vcmng.Data.Abstractions;
using Vcmng.Infrastructure.Models;
using Vcmng.Infrastructure.Settings;

namespace Vcmng.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        IMongoCollection<Category> _categories;

        public CategoryRepository(
            IMongoDbClient client,
            IMongoDbSetting settings
            )
        {
            _categories = client.Database.GetCollection<Category>(settings.CategoryCollectionName);
        }

        public async Task<Category> GetAsync(string id)
        {
            var result = await _categories.FindAsync(t => t.Id == id);
            return result.FirstOrDefault();
        }

        public async Task<List<Category>> GetAsync()
        {
            var result = await _categories.FindAsync(t => true);
            return result.ToList();
        }

        public async Task<Category> InsertAsync(Category category)
        {
            await _categories.InsertOneAsync(category);
            return category;
        }

        public async Task RemoveAsync(string id)
        {
            await _categories.DeleteOneAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(string id, Category category)
        {
            await _categories.ReplaceOneAsync(t => t.Id == id, category);
        }
    }
}
