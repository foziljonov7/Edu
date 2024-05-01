using Edu.API.Helpers;
using Edu.DAL.DTOs.CourseDTOs;
using Edu.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(
        ICourseService service,
        IValidator<CourseForCreateDto> createValidator,
        IValidator<CourseForUpdateDto> updateValidator) 
        : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetCourses()
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetCoursesAsync()
            });

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetCourseAsync(id)
            });

        [HttpPost("{id}/student/{studentId}")]
        public async Task<IActionResult> AddStudentAsync(
            [FromRoute] long id,
            [FromRoute] long studentId,
            CancellationToken cancellation = default)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.AddStudentAsync(id, studentId, cancellation)
            });

        [HttpPost]
        public async Task<IActionResult> CreateCourse(
            [FromBody] CourseForCreateDto dto)
        {
            var result = await createValidator.ValidateAsync(dto);

            if (!result.IsValid)
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
                    Data = await service.CreateCourseAsync(dto)
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(
            [FromRoute] int id,
            CourseForUpdateDto dto)
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

            return Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.UpdateCourseAsync(id, dto)
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.DeleteCourseAsync(id)
            });

        [HttpGet("students/{id}")]
        public async Task<IActionResult> GetByStudents(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetCourseByStudentsAsync(id)
            });
    }
}
