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

        [HttpPost("create")]
        public async Task<IActionResult> CreateTeacher(
            [FromBody] TeacherForCreateDto dto)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.CreateTeacherAsync(dto)
            });
    }
}
