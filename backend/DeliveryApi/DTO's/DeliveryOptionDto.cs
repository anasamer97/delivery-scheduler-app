namespace CallCenterAPI.DTO_s
{
	public class DeliveryOptionDto
	{
		public DateTime Date { get; set; } // e.g., 2025-06-06
		public string DayOfWeek => Date.ToString("dddd"); // e.g., "Friday"

		public List<DeliverySlotDto> TimeSlots { get; set; } = new List<DeliverySlotDto>();
	}
}
