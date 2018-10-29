using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.DataProvider;
using LinqToDB.DataProvider.SqlServer;

namespace L2DBInterfaceMappingExample
{
	public  class Linq2DbInitializer
	{
		public static bool HasLoadedFluent = false;
		private static object Lock = new Object();


		/// <summary>
		/// Ensures that all our schemas are bound and in-memory
		/// </summary>
		/// <param name="prov"></param>
		/// <param name="conn"></param>
		private void CreateMappings(IDataProvider prov, IDbConnection conn)
		{
			lock (Lock)
			{
				if (!HasLoadedFluent)
				{
					new Linq2DbRepository(prov, conn).MapTables();
					HasLoadedFluent = true;
				}
			}
		}

		

		/// <summary>
		/// Creates an entity instance with the given connection string
		/// </summary>
		/// <returns></returns>
		public ICartRepository Create()
		{
			var name = "ApplicationDBConnectionString";
			var config = System.Configuration.ConfigurationManager.ConnectionStrings[name];
			if (config == null || string.IsNullOrWhiteSpace(config.ConnectionString)) throw new Exception($"{name} has not been configured");
			var connectionString =  config.ConnectionString;

			var prov = new SqlServerDataProvider("", SqlServerVersion.v2012);
			var conn = new SqlConnection(connectionString);
			this.CreateMappings(prov, conn);

			var result = new Linq2DbRepository(prov, conn);
			return result;
		}

	}
}
