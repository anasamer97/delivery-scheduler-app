using CallCenterAPI.Enum;

namespace CallCenterAPI.Classes
{
	public class Order
	{
		public int OrderId { get; set; }
		public ICollection<Product> Products = new List<Product>();		
	
	}
}
