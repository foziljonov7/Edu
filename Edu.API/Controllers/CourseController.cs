using Edu.API.Helpers;
using Edu.DAL.DTOs.CourseDTOs;
using Edu.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

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

        [HttpGet("course/{id}")]
        public async Task<IActionResult> GetCourse(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetCourseAsync(id)
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

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCourse(
            [FromRoute] int id,
            CourseForUpdateDto dto)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.UpdateCourseAsync(id, dto)
            });

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCourse(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.DeleteCourseAsync(id)
            });

        [HttpGet("getByStudents/{id}")]
        public async Task<IActionResult> GetByStudents(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetCourseByStudentsAsync(id)
            });

        [HttpPost("{courseId}/AddStudent/{studentId}")]
        public async Task<IActionResult> AddStudentByCourseAsync(
            [FromRoute] long courseId,
            [FromRoute] long studentId)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.AddStudentByCourseAsync(courseId, studentId)
            });
    }
}
