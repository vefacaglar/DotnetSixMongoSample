using System.Collections.Generic;
using System.Threading.Tasks;
using Vcmng.Infrastructure.Models;

namespace Vcmng.Data.Abstractions
{
    public interface IProductRepository
    {
        Task<Product> InsertAsync(Product product);
        Task<Product> GetAsync(string id);
        Task<List<Product>> GetAsync();
        Task RemoveAsync(string id);
        Task UpdateAsync(string id, Product product);
    }
}
