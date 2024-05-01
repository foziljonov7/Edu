using Edu.API.Helpers;
using Edu.DAL.DTOs.TeacherDTOs;
using Edu.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Edu.API.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class TeacherController(
        ITeacherService service,
        IValidator<TeacherForCreateDto> createValidator,
        IValidator<TeacherForUpdateDto> updateValidator) 
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTeachers()
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetTeachersAsync()
            });

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetTeacherAsync(id)
            });

        [HttpPost]
        public async Task<IActionResult> CreateTeacher(
            [FromBody] TeacherForCreateDto dto)
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
                    Data = await service.CreateTeacherAsync(dto)
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(
            [FromRoute] int id,
            TeacherForUpdateDto dto)
        {
            var result = await updateValidator.ValidateAsync(dto);

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
                    Data = await service.UpdateTeacherAsync(id, dto)
                });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.DeleteTeacherAsync(id)
            });

        [HttpGet("courses/search")]
        public async Task<IActionResult> GetByCourses(
            [FromQuery] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetTeacherByCoursesAsync(id)
            });
    }
}
