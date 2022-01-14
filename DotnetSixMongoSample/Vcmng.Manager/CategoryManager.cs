using System.Collections.Generic;
using System.Threading.Tasks;
using Vcmng.Data.Abstractions;
using Vcmng.Infrastructure.Models;
using Vcmng.Infrastructure.Request;
using Vcmng.Infrastructure.Response;
using Vcmng.Manager.Abstractions;

namespace Vcmng.Manager
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(
            ICategoryRepository categoryRepository
            )
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponse<Category>> InsertAsync(InsertCategoryRequest request)
        {
            return new BaseResponse<Category>
            {
                Data = await _categoryRepository.InsertAsync(new Category
                {
                    Description = request.Description,
                    Name = request.Name,
                }),
            };
        }

        public async Task<BaseResponse<List<Category>>> GetAsync()
        {
            return new BaseResponse<List<Category>>
            {
                Data = await _categoryRepository.GetAsync(),
            };
        }

        public async Task<BaseResponse<Category>> GetAsync(string id)
        {
            return new BaseResponse<Category>
            {
                Data = await _categoryRepository.GetAsync(id)
            };
        }

        public async Task<BaseResponse<object>> RemoveAsync(string id)
        {
            await _categoryRepository.RemoveAsync(id);
            return new BaseResponse<object> { };
        }

        public async Task<BaseResponse<Category>> UpdateAsync(string id, UpdateCategoryRequest request)
        {
            var category = new Category
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
            };
            await _categoryRepository.UpdateAsync(id, category);
            return new BaseResponse<Category>
            {
                Data = category,
            };
        }
    }
}
