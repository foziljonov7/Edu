using Edu.API.Helpers;
using Edu.DAL.DTOs.CourseDTOs;
using Edu.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService service;

        public CourseController(
            ICourseService service)
        {
            this.service = service;
        }

        [HttpGet("courses")]
        public async Task<IActionResult> GetCourses()
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetCoursesAsync()
            });

        [HttpPost("create")]
        public async Task<IActionResult> CreateCourse(
            [FromBody] CourseForCreateDto dto)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.CreateCourseAsync(dto)
            });
    }
}
