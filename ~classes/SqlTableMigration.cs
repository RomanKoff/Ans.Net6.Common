using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Ans.Net6.Common
{

	public class SqlTableMigration
	{

		public string OldName { get; private set; }
		public string NewName { get; private set; }
		public bool IsIdentityInsert { get; private set; }
		public List<SqlFieldMigration> Fields { get; private set; }


		public SqlTableMigration(
			string oldName,
			string newName,
			bool isIdentityInsert,
			params string[] fieldsDefinitions)
		{
			this.Fields = new List<SqlFieldMigration>();
			this.OldName = oldName;
			this.NewName = newName ?? oldName;
			this.IsIdentityInsert = isIdentityInsert;
			foreach (string s1 in fieldsDefinitions)
			{
				string s2 = s1.Trim();
				if (!string.IsNullOrEmpty(s2))
					this.Fields.Add(new SqlFieldMigration(s2));
			}
		}


		public string GetSql(
			SqlConnection connection)
		{
			var sb = new StringBuilder();
			string query = $"SELECT * FROM {OldName};";
			var command = new SqlCommand(query, connection);
			var reader = command.ExecuteReader();
			sb.Append($"\n-- {OldName} > {NewName}\n\n");
			if (IsIdentityInsert)
				sb.Append($"SET IDENTITY_INSERT [dbo].[{NewName}] ON\n");
			while (reader.Read())
				MakeInsert(reader, sb);
			if (IsIdentityInsert)
				sb.Append($"SET IDENTITY_INSERT [dbo].[{NewName}] OFF\n");
			sb.Append("\nGO\n");
			reader.Close();
			return sb.ToString();
		}


		public void MakeInsert(
			SqlDataReader reader,
			StringBuilder sb)
		{
			var names = new StringBuilder();
			var values = new StringBuilder();
			foreach (var field in Fields)
			{
				names.Append($", [{field.NewField.Name}]");
				if (field.IsSetup)
					values.Append($", {field.Value}");
				else
					values.Append($", {GetValue(field.NewField.Type, reader[field.OldField.Name])}");
			}
			sb.AppendLine($"INSERT [dbo].[{NewName}] ({names.ToString()[2..]})");
			sb.AppendLine($"\tVALUES ({values.ToString()[2..]})");
		}


		public string GetValue(
			SqlFieldTypesEnum type,
			object value)
		{
			switch (type)
			{
				case SqlFieldTypesEnum.IntNullabel:
					return SuppSql.GetValueAsIntOrNULL(value);
				case SqlFieldTypesEnum.Real:
					return SuppSql.GetValueAsDoubleOrNULL(value);
				case SqlFieldTypesEnum.Boolean:
					return SuppSql.GetValueAsBool(value);
				case SqlFieldTypesEnum.DateTime:
					return SuppSql.GetValueAsDateTime(value);
				default:
					break;
			}
			return SuppSql.GetValue(value.ToString());
		}

	}

}
