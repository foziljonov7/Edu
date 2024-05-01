using Edu.API.Helpers;
using Edu.DAL.DTOs.PaymentDTOs;
using Edu.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace Edu.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController(IPaymentService service) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetPaymentsAsync(CancellationToken cancellation = default)
			=> Ok(new Response
			{
				Flag = true,
				Message = "Success",
				Data = await service.GetPaymentsAsync(cancellation)
			});

		[HttpGet("{id}")]
		public async Task<IActionResult> GetPaymentAsync(
			[FromRoute] long id,
			CancellationToken cancellation = default)
			=> Ok(new Response
			{
				Flag = true,
				Message = "Success",
				Data = await service.GetPaymentAsync(id, cancellation)
			});

		[HttpPost]
		public async Task<IActionResult> PostStudentForCourse(
			[FromBody] PaymentForCourseDto dto,
			CancellationToken cancellation = default)
			=> Ok(new Response
			{
				Flag = true,
				Message = "Success",
				Data = await service.PostPaymentForCourse(dto, cancellation)
			});
	}
}
