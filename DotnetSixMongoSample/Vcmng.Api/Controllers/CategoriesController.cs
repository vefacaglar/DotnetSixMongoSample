using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vcmng.Infrastructure.Models;
using Vcmng.Infrastructure.Request;
using Vcmng.Infrastructure.Response;
using Vcmng.Manager.Abstractions;

namespace Vcmng.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;

        public CategoriesController(
            ICategoryManager categoryManager
            )
        {
            _categoryManager = categoryManager;
        }

        /// <summary>
        /// gets all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<Category>>>> GetAsync()
        {
            return Ok(await _categoryManager.GetAsync());
        }

        /// <summary>
        /// insert new category
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseResponse<Category>>> InsertAsync([FromBody] InsertCategoryRequest request)
        {
            return Ok(await _categoryManager.InsertAsync(request));
        }

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Category>>> UpdateAsync(string id, [FromBody] UpdateCategoryRequest request)
        {
            return Ok(await _categoryManager.UpdateAsync(id, request));
        }

        /// <summary>
        /// get specific category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Category>>> GetAsync(string id)
        {
            return Ok(await _categoryManager.GetAsync(id));
        }

        /// <summary>
        /// delete category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<object>>> DeleteAsync(string id)
        {
            return Ok(await _categoryManager.RemoveAsync(id));
        }
    }
}
