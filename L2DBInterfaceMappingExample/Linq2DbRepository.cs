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

	public  class Linq2DbRepository : LinqToDB.Data.DataConnection, ICartRepository
	{
		

		public Linq2DbRepository(IDataProvider provider, IDbConnection conn) : base(provider, conn)
		{
		}

		public Linq2DbRepository(string connectionString) : base(connectionString)
		{
		}

		/// <summary>
		/// Maps our tables to the context
		/// </summary>
		public void MapTables()
		{
			var fluent = base.MappingSchema.GetFluentMappingBuilder();
			fluent.Entity<OrderItem>().HasAttribute(new LinqToDB.Mapping.TableAttribute() { IsColumnAttributeRequired = true, });
			fluent.Entity<OrderItem>().HasPrimaryKey(x => x.OrderItemID).HasIdentity(x => x.OrderItemID);
			fluent.Entity<OrderItem>().Property(x => x.OrderItemID).HasColumnName("OrderItemID");
			fluent.Entity<OrderItem>().Property(x => x.Quantity).HasColumnName("Quantity");
		}

		public virtual IQueryable<OrderItem> OrderItem {
			get { 
				return this.GetTable<OrderItem>();
			}
		}

		#region Implementation of ICartRepository

		public IQueryable<ICartItem> CartItem {
			get { return this.OrderItem; }
		}

		#endregion
	}
}
