using Edu.API.Helpers;
using Edu.DAL.DTOs.CategoryDTOs;
using Edu.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService service) : ControllerBase
    {
        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetCategoriesAsync()
            });

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategory(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetCategoryAsync(id)
            });

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory(
            [FromBody] CategoryForCreateDto dto)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.CreateCategoryAsync(dto)
            });

        [HttpGet("getBySubject/{id}")]
        public async Task<IActionResult> GetCategoryBySubjectAsync(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetCategoryBySubjectAsync(id)
            });
    }
}
