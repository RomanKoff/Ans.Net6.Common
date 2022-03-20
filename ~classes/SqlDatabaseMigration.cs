using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Ans.Net6.Common
{

	public class SqlDatabaseMigration
	{

		public string Servername { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string SourceDatabaseName { get; set; }
		public string TargetDatabaseName { get; set; }
		public List<SqlTableMigration> Tables { get; set; }


		public string GetSql()
		{
			var sb = new StringBuilder();
			string connectionString = $"Data Source={Servername};Initial Catalog={SourceDatabaseName};Persist Security Info=True;User ID={Username};Password={Password};Pooling=False";
			using (var c1 = new SqlConnection(connectionString))
			{
				c1.Open();
				foreach (var table in Tables)
					sb.Append(table.GetSql(c1));
			}
			return sb.ToString();
		}

	}

}
