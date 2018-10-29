using System.Dynamic;

namespace L2DBInterfaceMappingExample
{
	public class OrderItem : ICartItem
	{
		public int Quantity { get; set; }
		public int OrderItemID { get; set; }
		public string Name { get; set; }

		public int CartItemID {
			get { return OrderItemID; }
			set { OrderItemID = value; }
		}
	}
}