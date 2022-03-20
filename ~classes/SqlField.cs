using System;

namespace Ans.Net6.Common
{

	public enum SqlFieldTypesEnum
	{
		Boolean,
		DateTime,
		IntNullabel,
		Int,
		Real,
		Text,
	}



	public class SqlField
	{

		public string Name { get; private set; }
		public SqlFieldTypesEnum Type { get; private set; }
		public Func<object, string> FuncToString { get; private set; }

		protected string Value { get; set; }


		public SqlField(
			SqlFieldTypesEnum type,
			string name)
		{
			_init(type, name);
		}


		public SqlField(
			SqlFieldTypesEnum type,
			string name,
			string value)
			: this(type, name)
		{
			this.Value = value;
		}


		public SqlField(
			string definition)
		{
			switch (definition[0])
			{
				case '#': // Number? (int?, bigint?)
					_init(SqlFieldTypesEnum.IntNullabel, definition[1..]);
					break;
				case '+': // Number (int, bigint)
					_init(SqlFieldTypesEnum.Int, definition[1..]);
					break;
				case '%': // Number (float, real)
					_init(SqlFieldTypesEnum.Real, definition[1..]);
					break;
				case '@': // Datetime (datetime)
					_init(SqlFieldTypesEnum.DateTime, definition[1..]);
					break;
				case '&': // Boolean (bit)
					_init(SqlFieldTypesEnum.Boolean, definition[1..]);
					break;
				default: // Others
					_init(SqlFieldTypesEnum.Text, definition);
					break;
			}
		}


		public string GetValue(
			object value)
		{
			return FuncToString(value);
		}


		public string GetValue()
		{
			return FuncToString(Value);
		}



		// privates

		private void _init(
			SqlFieldTypesEnum type,
			string name)
		{
			this.Type = type;
			this.Name = name;
			this.FuncToString = type switch
			{
				// Number? (int?, bigint?)
				SqlFieldTypesEnum.IntNullabel => x => SuppSql.GetValueAsIntOrNULL(x),
				// Number (int, bigint)
				SqlFieldTypesEnum.Int => x => SuppSql.GetValueAsIntOr0(x),
				// Number (float, real)
				SqlFieldTypesEnum.Real => x => SuppSql.GetValueAsDoubleOrNULL(x),
				// Datetime (datetime)
				SqlFieldTypesEnum.DateTime => x => SuppSql.GetValueAsDateTime(x),
				// Boolean (bit)
				SqlFieldTypesEnum.Boolean => x => SuppSql.GetValueAsBool(x),
				// Others
				_ => x => SuppSql.GetValue((string)x),
			};
		}

	}

}
