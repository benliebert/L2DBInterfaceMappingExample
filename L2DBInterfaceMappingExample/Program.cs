using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2DBInterfaceMappingExample
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var cxt = new Linq2DbInitializer().Create()) {
				var data = (
						from item in cxt.CartItem
						select item
					);

				// Works
				var allItems = data.ToList();

				// Fails
				var filtered = data.Where(x => x.CartItemID == 1).ToList();
			}

		}
	}
}
