using Edu.API.Helpers;
using Edu.DAL.DTOs.TeacherDTOs;
using Edu.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Edu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController(ITeacherService service) : ControllerBase
    {
        [HttpGet("teachers")]
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateTeacher(
            [FromBody] TeacherForCreateDto dto)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.CreateTeacherAsync(dto)
            });

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTeacher(
            [FromRoute] int id,
            TeacherForUpdateDto dto)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.UpdateTeacherAsync(id, dto)
            });

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTeacher(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.DeleteTeacherAsync(id)
            });

        [HttpGet("getByStudent/{name}")]
        public async Task<IActionResult> GetByName(
            [FromRoute] string name)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetStudentByNameAsync(name)
            });

        [HttpGet("getByCourses/{id}")]
        public async Task<IActionResult> GetByCourses(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetTeacherByCoursesAsync(id)
            });
    }
}
