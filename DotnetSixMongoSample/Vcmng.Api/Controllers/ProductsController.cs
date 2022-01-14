using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vcmng.Infrastructure.Models;
using Vcmng.Infrastructure.Request;
using Vcmng.Infrastructure.Response;
using Vcmng.Manager.Abstractions;

namespace Vcmng.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductsController(
            IProductManager productManager
            )
        {
            _productManager = productManager;
        }

        /// <summary>
        /// gets product detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<GetProductResponse>>> GetAsync(string id)
        {
            return Ok(await _productManager.GetAsync(new GetProductRequest
            {
                Id = id
            }));
        }

        /// <summary>
        /// insert new product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseResponse<Product>>> InsertAsync([FromBody] InsertProductRequest request)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _productManager.InsertAsync(request));
            }
            return BadRequest(new BaseResponse<Product> { Message = "not valid" });
        }

        /// <summary>
        /// update product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Product>>> UpdateAsync(string id, [FromBody] UpdateProductRequest request)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _productManager.UpdateAsync(id, request));
            }
            return BadRequest(new BaseResponse<Product>
            {
                Message = "not valid",
            });
        }

        /// <summary>
        /// get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<Product>>>> GetProductsAsync()
        {
            return Ok(await _productManager.GetAsync());
        }

        /// <summary>
        /// removes product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<object>>> DeleteAsync(string id)
        {
            return Ok(await _productManager.RemoveAsync(id));
        }
    }
}
