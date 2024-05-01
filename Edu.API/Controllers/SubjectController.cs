using Edu.API.Helpers;
using Edu.DAL.DTOs.SubjectDTOs;
using Edu.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Edu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController(
        ISubjectService service,
        IValidator<SubjectForCreateDto> createValidator,
        IValidator<SubjectForUpdateDto> updateValidator)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSubjects()
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetSubjectsAsync()
            });

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubject(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetSubjectAsync(id)
            });

        [HttpPost]
        public async Task<IActionResult> CreateSubject(
            [FromBody] SubjectForCreateDto dto)
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
                    Data = await service.CreateSubjectAsync(dto)
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(
            [FromRoute] int id,
            SubjectForUpdateDto dto)
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
                    Data = await service.UpdateSubjectAsync(id, dto)
                });
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetByCategory(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetSubjectByCategoryAsync(id)
            });
    }
}
