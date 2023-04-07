using Microsoft.AspNetCore.Mvc;
using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class Parte3Controller :  ControllerBase
	{
		private readonly IOrderService _orderService;
        public Parte3Controller(IOrderService orderService)
		{
			_orderService = orderService;
		}
		[HttpGet("orders")]
		public async Task<IActionResult> PlaceOrder(string paymentMethod, decimal paymentValue, int customerId)
		{
			try
			{
                var result = await _orderService.PayOrder(paymentMethod, paymentValue, customerId);

                if (result is null) return NotFound();

                return Ok(result);
            }
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					IdRequisicao = Guid.NewGuid(),
					Error = ex.Message
				});
				
			}
		}
	}
}
