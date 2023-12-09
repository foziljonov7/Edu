using Edu.Data;
using Edu.Dtos;
using Edu.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Edu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService service;
        private readonly IValidator<CreateCourseDto> createValidator;
        private readonly IValidator<UpdateCourseDto> updateValidator;

        public CourseController(ICourseService service,
            IValidator<CreateCourseDto> createValidator,
            IValidator<UpdateCourseDto> updateValidator)
        {
            this.service = service;
            this.createValidator = createValidator;
            this.updateValidator = updateValidator;
        }

        [HttpPost("CreateCourse")]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDto dto,
            [FromForm] IFormFile imageFile)
        {
            var validationResult = await createValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var request = await service.CreateCourse(dto, imageFile);
            return CreatedAtAction(nameof(GetCourse), new { id = request.Id }, request);
        }

        [HttpGet("Courses")]
        public async Task<IActionResult> GetCourses()
        {
            var request = await service.GetCourses();
            return Ok(request);
        }

        [HttpGet("Course/{id}")]
        public async Task<IActionResult> GetCourse([FromRoute] Guid id)
        {
            var request = await service.GetCourse(id);
            return Ok(request);
        }
        [HttpPut("UpdateCourse/{id}")]
        public async Task<IActionResult> UpdateCourse(
            [FromRoute] Guid id,
            UpdateCourseDto dto)
        {
            var validationResult = await updateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var request = await service.UpdateCourse(id, dto);
            return Ok(request);
        }
        [HttpDelete("DeleteCourse/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var request = await service.DeleteCourse(id);
            return Ok(request);
        }
        [HttpGet("Course/Students/{id}")]
        public async Task<IActionResult> GetCourseStudent([FromRoute] Guid id)
        {
            var request = await service.GetCourseStudent(id);
            return Ok(request);
        }
    } 
}
