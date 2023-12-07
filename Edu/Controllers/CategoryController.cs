using Edu.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
