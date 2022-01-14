using System.Collections.Generic;
using System.Threading.Tasks;
using Vcmng.Infrastructure.Models;

namespace Vcmng.Data.Abstractions
{
    public interface ICategoryRepository
    {
        Task<Category> InsertAsync(Category product);
        Task<Category> GetAsync(string id);
        Task<List<Category>> GetAsync();
        Task RemoveAsync(string id);
        Task UpdateAsync(string id, Category product);
    }
}
