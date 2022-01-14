using System.Collections.Generic;
using System.Threading.Tasks;
using Vcmng.Data.Abstractions;
using Vcmng.Infrastructure.Constants;
using Vcmng.Infrastructure.Models;
using Vcmng.Infrastructure.Request;
using Vcmng.Infrastructure.Response;
using Vcmng.Manager.Abstractions;
using Vcmng.Manager.Cache;

namespace Vcmng.Manager
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICacheProvider _cacheProvider;

        public ProductManager(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            ICacheProvider cacheProvider
            )
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _cacheProvider = cacheProvider;
        }

        public async Task<BaseResponse<GetProductResponse>> GetAsync(GetProductRequest request)
        {
            var response = await _cacheProvider.GetAsync($"ProductDetail:{request.Id}", async () =>
            {
                var product = await _productRepository.GetAsync(request.Id);
                var category = await _categoryRepository.GetAsync(product.CategoryId);
                return new GetProductResponse
                {
                    Category = category,
                    Currency = product.Currency,
                    Description = product.Description,
                    Name = product.Name,
                    Id = product.Id,
                    Price = product.Price,
                };
            }, CacheTimes.FiveMinutes);

            return new BaseResponse<GetProductResponse>
            {
                Data = response,
            };
        }

        public async Task<BaseResponse<List<Product>>> GetAsync()
        {
            return new BaseResponse<List<Product>>
            {
                Data = await _productRepository.GetAsync()
            };
        }

        public async Task<BaseResponse<Product>> InsertAsync(InsertProductRequest request)
        {
            var response = await _productRepository.InsertAsync(new Product
            {
                CategoryId = request.CategoryId,
                Currency = request.Currency,
                Description = request.Description,
                Name = request.Name,
                Price = request.Price,
            });
            return new BaseResponse<Product>
            {
                Data = response,
            };
        }

        public async Task<BaseResponse<object>> RemoveAsync(string id)
        {
            await _productRepository.RemoveAsync(id);
            return new BaseResponse<object> { };
        }

        public async Task<BaseResponse<Product>> UpdateAsync(string id, UpdateProductRequest request)
        {
            var product = new Product
            {
                Id = id,
                CategoryId = request.CategoryId,
                Currency = request.Currency,
                Description = request.Description,
                Name = request.Name,
                Price = request.Price
            };
            await _productRepository.UpdateAsync(id, product);
            return new BaseResponse<Product>
            {
                Data = product,
            };
        }
    }
}
