using CallCenterAPI.DTO_s;
using CallCenterAPI.Enum;

namespace CallCenterAPI.Services
{
	public class DeliveryService
	{
		
		public DateTime GetEarliestCommonDeliveryDate(List<ProductDto> products, DateTime now)
		{
			DateTime earliestDate = now.Date;

			foreach (var product in products)
			{
				DateTime productDate;

				if (product.ProductType == "InStockProducts")
				{
					productDate = (now < now.Date.AddHours(18)) ? now.Date : now.Date.AddDays(1);
				}
				else if (product.ProductType == "FreshFoodProducts")
				{
					productDate = (now < now.Date.AddHours(12)) ? now.Date : now.Date.AddDays(1);
				}
				else // ExternalProducts
				{
					productDate = now.Date.AddDays(3);
				}

				if (productDate > earliestDate)
					earliestDate = productDate;
			}

			return earliestDate;
		}


	

		public List<DeliveryOptionDto> GetAvailableDeliveryOptions(List<ProductDto> products, DateTime now)
		{
			var earliestDate = GetEarliestCommonDeliveryDate(products, now);

			var options = new List<DeliveryOptionDto>();

			for (int i = 0; i < 14; i++)
			{
				var date = earliestDate.AddDays(i);

				// Check weekday constraint
				if (date.DayOfWeek < DayOfWeek.Monday || date.DayOfWeek > DayOfWeek.Friday)
					continue;

				// Check ExternalProduct constraint (Tuesday to Friday)
				bool hasExternal = products.Any(p => p.ProductType == "ExternalProducts");
				if (hasExternal && date.DayOfWeek == DayOfWeek.Monday)
					continue;

				var slots = new List<DeliverySlotDto>();

				for (int hour = 8; hour < 22; hour++)
				{
					var isGreen = IsGreenSlot(hour);

					slots.Add(new DeliverySlotDto
					{
						StartTime = $"{hour:00}:00",
						EndTime = $"{hour + 1:00}:00",
						IsGreen = isGreen
					});
				}

				var sortedSlots = slots.OrderByDescending(s => s.IsGreen).ThenBy(s => s.StartTime).ToList();

				options.Add(new DeliveryOptionDto
				{
					Date = date,
					TimeSlots = sortedSlots
				});
			}

			return options;
		}


		private bool IsGreenSlot(int hour)
		{
			return (hour >= 13 && hour < 15) || (hour >= 20 && hour < 22);
		}


	}
}
