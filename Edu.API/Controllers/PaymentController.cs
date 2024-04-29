using Edu.API.Helpers;
using Edu.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Edu.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController(IPaymentService service) : ControllerBase
	{
		[HttpGet("payments")]
		public async Task<IActionResult> GetPayments()
			=> Ok(new Response
			{
				Flag = true,
				Message = "Success",
				Data = await service.GetPaymentsAsync()
			});
	}
}
