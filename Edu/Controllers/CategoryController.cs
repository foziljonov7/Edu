using Edu.Entities;
using Edu.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Edu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
            => this.service = service;
        [HttpGet("Categorys")]
        public async Task<IActionResult> GetCategories()
        {
            var request = await service.GetCategories();
            return Ok(request);
        }
        [HttpGet("Category/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var request = await service.GetCategory(id);
            return Ok(request);
        }
        [HttpGet("Course/Category/{id}")]
        public async Task<IActionResult> GetCourseCategory(int id)
        {
            var request = await service.GetCoursesCategory(id);
            return Ok(request);
        }
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] Category newCategory)
        {
            var request = await service.CreateCategory(newCategory);
            return Ok(request);
        }
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var request = await service.UpdateCategory(category);
            return Ok(request);
        }
        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var request = await service.DeleteCategory(id);
            return Ok(request);
        }
    }
}
