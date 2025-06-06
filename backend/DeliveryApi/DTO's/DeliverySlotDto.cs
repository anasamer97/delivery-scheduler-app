namespace CallCenterAPI.DTO_s
{
	public class DeliverySlotDto
	{
		public string StartTime { get; set; } // "13:00"
		public string EndTime { get; set; }   // "14:00"
		public bool IsGreen { get; set; }     // True if it's a green slot
	}

}
