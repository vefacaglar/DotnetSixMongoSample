using System.Collections.Generic;
using System.Threading.Tasks;
using Vcmng.Infrastructure.Models;
using Vcmng.Infrastructure.Request;
using Vcmng.Infrastructure.Response;

namespace Vcmng.Manager.Abstractions
{
    public interface ICategoryManager
    {
        Task<BaseResponse<Category>> InsertAsync(InsertCategoryRequest request);
        Task<BaseResponse<List<Category>>> GetAsync();
        Task<BaseResponse<Category>> GetAsync(string id);
        Task<BaseResponse<object>> RemoveAsync(string id);
        Task<BaseResponse<Category>> UpdateAsync(string id, UpdateCategoryRequest request);
    }
}
