namespace L2DBInterfaceMappingExample
{
	public interface ICartItem
	{
		int CartItemID { get; set; }
		int Quantity { get; set; }
		string Name { get; set; }
	}
}