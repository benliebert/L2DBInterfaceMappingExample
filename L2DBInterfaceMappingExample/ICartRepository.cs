using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider;
using LinqToDB.Mapping;

using LinqToDB.Mapping;

namespace L2DBInterfaceMappingExample
{

	public interface ICartRepository : IDisposable
	{

		IQueryable<ICartItem> CartItem { get;  }

	}
}
