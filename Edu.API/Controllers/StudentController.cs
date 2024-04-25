using Edu.API.Helpers;
using Edu.DAL.DTOs.StudentDTOs;
using Edu.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Edu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService service) : ControllerBase
    {
        [HttpGet("students")]
        public async Task<IActionResult> GetStudents()
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetStudentsAsync()
            });

        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetStudent(

            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetStudentAsync(id)
            });

        [HttpPost("create")]
        public async Task<IActionResult> CreateStudent(
            [FromBody] StudentForCreateDto dto)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.CreateStudentAsync(dto)
            });

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateStudent(
            [FromRoute] int id,
            StudentForUpdateDto dto)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.UpdateStudentAsync(id, dto)
            });

        [HttpGet("getByCourses/{id}")]
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
