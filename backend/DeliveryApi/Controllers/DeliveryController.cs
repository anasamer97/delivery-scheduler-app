using CallCenterAPI.DTO_s;
using CallCenterAPI.Enum;
using CallCenterAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CallCenterAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DeliveryController : ControllerBase
	{
		private readonly DeliveryService _deliveryService;

		public DeliveryController(DeliveryService deliveryService)
		{
			_deliveryService = deliveryService;
		}



		[HttpPost("get-delivery-options")]
		public IActionResult GetDeliveryOptions([FromBody] List<ProductDto> products)
		{
			var options = _deliveryService.GetAvailableDeliveryOptions(products, DateTime.Now);
			return Ok(options);
		}


	
	}
}
