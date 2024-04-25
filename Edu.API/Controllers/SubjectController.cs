using Edu.API.Helpers;
using Edu.DAL.DTOs.SubjectDTOs;
using Edu.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Edu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController(ISubjectService service) : ControllerBase
    {
        [HttpGet("subjects")]
        public async Task<IActionResult> GetSubjects()
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetSubjectsAsync()
            });

        [HttpPost("create")]
        public async Task<IActionResult> CreateSubject(
            [FromBody] SubjectForCreateDto dto)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.CreateSubjectAsync(dto)
            });
    }
}
