using Edu.API.Helpers;
using Edu.DAL.DTOs.StudentDTOs;
using Edu.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Edu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(
        IStudentService service,
        IValidator<StudentForCreateDto> createValidator,
        IValidator<StudentForUpdateDto> updateValidator) 
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetStudents()
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetStudentsAsync()
            });

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(

            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetStudentAsync(id)
            });

        [HttpPost]
        public async Task<IActionResult> CreateStudent(
            [FromBody] StudentForCreateDto dto)
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
                    Data = await service.CreateStudentAsync(dto)
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(
            [FromRoute] int id,
            StudentForUpdateDto dto)
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
                    Data = await service.UpdateStudentAsync(id, dto)
                });
        }

        [HttpGet("courses/{id}")]
        public async Task<IActionResult> GetStudentByCourse(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetStudentByCoursesAsync(id)
            });
    } 
}
