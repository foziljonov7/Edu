﻿using Edu.API.Helpers;
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

        [HttpGet("subject/{id}")]
        public async Task<IActionResult> GetSubject(
            [FromRoute] int id)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.GetSubjectAsync(id)
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

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCourse(
            [FromRoute] int id,
            SubjectForUpdateDto dto)
            => Ok(new Response
            {
                Flag = true,
                Message = "Success",
                Data = await service.UpdateSubjectAsync(id, dto)
            });

        [HttpGet("getByCategory/{id}")]
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
