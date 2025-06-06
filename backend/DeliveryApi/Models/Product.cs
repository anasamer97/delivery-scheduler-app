using CallCenterAPI.Enum;

namespace CallCenterAPI.Classes
{
	public class Product
	{
		public int ProductId { get; set; }
		public int OrdertId { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }
		public int Quanitity { get; set; }

		public ProductType Type { get; set; }
		public Order Order { get; set; }
	}
}
