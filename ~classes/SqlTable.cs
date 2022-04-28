using System.Text;

namespace Ans.Net6.Common
{

	public class SqlTable
	{

		public List<SqlField> Fields { get; private set; }
		public StringBuilder Sql { get; private set; }
		public StringBuilder CurrentSql { get; private set; }
		public bool HasUpdate { get; private set; }
		public string TableName { get; private set; }
		public string FieldsNames { get; private set; }


		public SqlTable(
			string tableName,
			string definition)
		{
			this.Sql = new StringBuilder();
			this.TableName = tableName;
			this.Fields = definition.Split(_Const.SPLIT_ITEMS)
				.Select(x => new SqlField(x)).ToList();
			this.FieldsNames = Fields.MakeFromCollection(x => x.Name, "{0}", "[{0}]", ",");
		}


		public void AddInsert(
			IEnumerable<SqlField> fields,
			object item)
		{
			this.CurrentSql = new StringBuilder();
			for (int i1 = 0; i1 < fields.Count(); i1++)
			{
				if (i1 > 0)
					CurrentSql.Append(',');
				CurrentSql.Append(Fields[i1].GetValue(item.GetPropertyValue(Fields[i1].Name)));
			};
			Sql.Append($"INSERT [{TableName}] ({FieldsNames}) VALUES ({CurrentSql});");
		}


		public void AddInsert(
			object item)
		{
			AddInsert(Fields, item);
		}


		public void AddInsert(
			string fieldsDefinition,
			object item)
		{
			var fields = fieldsDefinition.Split(_Const.SPLIT_ITEMS)
				.Select(x => new SqlField(x));
			AddInsert(fields, item);
		}


		public void AddUpdate(
			string keyName,
			long keyValue,
			IEnumerable<SqlField> fields,
			object oldItem,
			object newItem,
			Func<object, object, bool> differentNew2Old)
		{
			this.CurrentSql = new StringBuilder();
			this.HasUpdate = false;
			bool f1 = false;
			for (int i1 = 0; i1 < fields.Count(); i1++)
			{
				var newValue = newItem.GetPropertyValue(Fields[i1].Name);
				var oldValue = oldItem.GetPropertyValue(Fields[i1].Name);
				if (differentNew2Old(newValue, oldValue))
				{
					this.HasUpdate = true;
					if (f1)
						CurrentSql.Append(',');
					else
						f1 = true;
					CurrentSql.Append($"[{Fields[i1].Name}]={Fields[i1].GetValue(newValue)}");
				}
			};
			if (HasUpdate)
				Sql.Append($"UPDATE [{TableName}] SET {CurrentSql} WHERE [{keyName}]={keyValue};\n");
		}


		public void AddUpdate(
			string keyName,
			long keyValue,
			object oldItem,
			object newItem,
			Func<object, object, bool> differentNew2Old)
		{
			AddUpdate(keyName, keyValue, Fields, oldItem, newItem, differentNew2Old);
		}


		public void AddUpdate(
			string keyName,
			long keyValue,
			string fieldsDefinition,
			object oldItem,
			object newItem,
			Func<object, object, bool> differentNew2Old)
		{
			var fields = fieldsDefinition.Split(_Const.SPLIT_ITEMS)
				.Select(x => new SqlField(x));
			AddUpdate(keyName, keyValue, fields, oldItem, newItem, differentNew2Old);
		}

	}

}
