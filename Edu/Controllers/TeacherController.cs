using Edu.Dtos;
using Edu.Entities;
using Edu.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService service;
        private readonly IValidator<CreateTeacherDto> createValidator;
        private readonly IValidator<UpdateTeacherDto> updateValidator;

        public TeacherController(ITeacherService service,
            IValidator<CreateTeacherDto> createValidator,
            IValidator<UpdateTeacherDto> updateValidator)
        {
            this.service = service;
            this.createValidator = createValidator;
            this.updateValidator = updateValidator;
        }
        [HttpPost("CreateTeacher")]
        public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherDto dto)
        {
            var validationResult = await createValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var request = await service.CreateTeacher(dto);
            return CreatedAtAction(nameof(GetTeacher), new { id = request.Id }, request);
        }

        [HttpGet("Teachers")]
        public async Task<IActionResult> GetTeachers()
        {
            var request = await service.GetTeachers();
            return Ok(request);
        }

        [HttpGet("Teacher/{id}")]
        public async Task<IActionResult> GetTeacher([FromRoute] Guid id)
        {
            var request = await service.GetTeacher(id);
            return Ok(request);
        }

    } 
}
