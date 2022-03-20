using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace Ans.Net6.Common
{

	public static partial class _e
	{

		public static void DeleteObjects<TEntity>(
			this DbSet<TEntity> set,
			IEnumerable<TEntity> data)
			where TEntity : class
		{
			foreach (var e in data)
				set.Remove(e);
		}


		public static void SqlClearTable(
			this DbContext context,
			string table)
		{
			_ = context.Database.ExecuteSqlRaw(
				string.Format(
					"DELETE FROM {0};DBCC CHECKIDENT('{0}', RESEED, 0);",
					table));
			_ = context.SaveChanges();
		}


		public static void SqlIdentityInserts(
			this DbContext context,
			string table,
			string inserts,
			bool hasIdentity)
		{
			if (!string.IsNullOrEmpty(inserts))
			{
				var sb = new StringBuilder(inserts);
				if (hasIdentity)
				{
					sb.Insert(0, SuppSql.GetSqlIdentityInsertOn(table));
					sb.Append(SuppSql.GetSqlIdentityInsertOff(table));
				}
				_ = context.Database.ExecuteSqlRaw(sb.ToString());
			}
		}


		public static void SqlIdentityInserts(
			this DbContext context,
			SqlTable table,
			bool hasIdentity)
		{
			context.SqlIdentityInserts(
				table.TableName,
				table.Sql.ToString(),
				hasIdentity);
		}


		//public static void DbccCheckIdent<T>(
		//    this DbContext context,
		//    int? reseedTo = null)
		//    where T : class
		//{
		//    context.Database.ExecuteSqlCommand(
		//        $"DBCC CHECKIDENT('{context.GetTableName<T>()}',RESEED{(reseedTo != null ? "," + reseedTo : "")});" +
		//        $"DBCC CHECKIDENT('{context.GetTableName<T>()}',RESEED);");
		//}


		//public static string GetTableName<T>(
		//    this DbContext context)
		//    where T : class
		//{
		//    var objectContext = ((IObjectContextAdapter)context).ObjectContext;
		//    return objectContext.GetTableName<T>();
		//}


		//public static string GetTableName<T>(
		//    this ObjectContext context)
		//    where T : class
		//{
		//    var sql = context.CreateObjectSet<T>().ToTraceString();
		//    var regex = new Regex(@"FROM\s+(?<table>.+)\s+AS");
		//    var match = regex.Match(sql);
		//    var table = match.Groups["table"].Value;
		//    return table;
		//}

	}

}