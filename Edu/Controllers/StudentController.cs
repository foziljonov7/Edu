using Edu.Dtos;
using Edu.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService service;
        private readonly IValidator<CreateStudentDto> createValidator;
        private readonly IValidator<UpdateStudentDto> updatevalidator;

        public StudentController(IStudentService service,
            IValidator<CreateStudentDto> createValidator,
            IValidator<UpdateStudentDto> updateValidator)
        {
            this.service = service;
            this.createValidator = createValidator;
            this.updatevalidator = updateValidator;
        }

        [HttpGet("Students")]
        public async Task<IActionResult> GetStudents()
        {
            var request = await service.GetStudents();
            return Ok(request);
        }
        [HttpGet("Student/{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] Guid id)
        {
            var request = await service.GetStudent(id);
            return Ok(request);
        }
        [HttpPost("CreateStudent")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto dto)
        {
            var validationResult = await createValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var request = await service.CreateStudent(dto);
            return CreatedAtAction(nameof(GetStudent), new { id = request.Id }, request);
        }
        [HttpPut("UpdateStudent/{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id,
            UpdateStudentDto dto)
        {
            var validationResult = await updatevalidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var request = await service.UpdateStudent(id, dto);
            return Ok(request);
        }
        [HttpDelete("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var request = await service.DeleteStudent(id);
            return Ok(request);
        }
    }
}
