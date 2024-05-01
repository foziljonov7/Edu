using Edu.API.Helpers;
using Edu.DAL.DTOs.CategoryDTOs;
using Edu.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(
        ICategoryService service,
        IValidator<CategoryForCreateDto> createValidator,
        IValidator<CategoryForUpdateDto> updateValidator)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCategories()
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetCategoriesAsync()
            });

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetCategoryAsync(id)
            });

        [HttpPost]
        public async Task<IActionResult> CreateCategory(
            [FromBody] CategoryForCreateDto dto)
        {
            var result = await createValidator.ValidateAsync(dto);

            if(!result.IsValid)
            {
                var errorMessage = string.Join("\n ", result.Errors.Select(dto => dto.ErrorMessage));

                return Ok(new Response
                {
                    Flag = false,
                    Message = errorMessage,
                    Data = null
                });
            }
            else
                return Ok(new Response
                {
                    Flag = true,
                    Message = "Success",
                    Data = await service.CreateCategoryAsync(dto)
                });
        }

        [HttpGet("subject/{id}")]
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
