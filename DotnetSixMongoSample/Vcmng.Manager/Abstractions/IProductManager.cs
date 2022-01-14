using System.Collections.Generic;
using System.Threading.Tasks;
using Vcmng.Infrastructure.Models;
using Vcmng.Infrastructure.Request;
using Vcmng.Infrastructure.Response;

namespace Vcmng.Manager.Abstractions
{
    public interface IProductManager
    {
        Task<BaseResponse<List<Product>>> GetAsync();
        Task<BaseResponse<GetProductResponse>> GetAsync(GetProductRequest request);
        Task<BaseResponse<Product>> InsertAsync(InsertProductRequest request);
        Task<BaseResponse<Product>> UpdateAsync(string id, UpdateProductRequest product);
        Task<BaseResponse<object>> RemoveAsync(string id);
    }
}
