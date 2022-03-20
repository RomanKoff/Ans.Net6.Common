using System;
using System.Globalization;

namespace Ans.Net6.Common
{

	public static class SuppSql
	{

		public static string GetSqlIdentityInsertOn(
			string table)
		{
			return $"SET IDENTITY_INSERT [{table}] ON;";
		}


		public static string GetSqlIdentityInsertOff(
			string table)
		{
			return $"SET IDENTITY_INSERT [{table}] OFF;";
		}


		public static string GetValue(
			int value)
		{
			return value.ToString();
		}


		public static string GetValue(
			int? value)
		{
			if (value == null)
				return "NULL";
			return GetValue(value.Value);
		}


		public static string GetValue(
			long value)
		{
			return value.ToString();
		}


		public static string GetValue(
			long? value)
		{
			if (value == null)
				return "NULL";
			return GetValue(value.Value);
		}


		public static string GetValue(
			double value)
		{
			return value.ToString(
				CultureInfo.InvariantCulture);
		}


		public static string GetValue(
			double? value)
		{
			if (value == null)
				return "NULL";
			return GetValue(value.Value);
		}


		public static string GetValue(
			float value)
		{
			return value.ToString(
				CultureInfo.InvariantCulture);
		}


		public static string GetValue(
			float? value)
		{
			if (value == null)
				return "NULL";
			return GetValue(value.Value);
		}


		public static string GetValue(
			decimal value)
		{
			return value.ToString(
				CultureInfo.InvariantCulture);
		}


		public static string GetValue(
			decimal? value)
		{
			if (value == null)
				return "NULL";
			return GetValue(value.Value);
		}


		public static string GetValue(
			string value)
		{
			if (string.IsNullOrEmpty(value))
				return "NULL";
			string s1 = value.Replace("'", "''");
			return $"N'{s1}'";
		}


		public static string GetValue(
			bool value)
		{
			if (value)
				return "-1";
			return "0";
		}


		public static string GetValue(
			DateTime value)
		{
			string s1 = value.ToString("yyyy-MM-dd HH:mm:ss.000");
			return $"CAST(N'{s1}' AS DateTime)";
		}


		public static string GetValue(
			DateTime? value)
		{
			if (value == null)
				return "NULL";
			return GetValue(value.Value);
		}


		public static string GetValueAsIntOrNULL(
			object value)
		{
			return GetValue(
				value?.ToString().ToInt());
		}


		public static string GetValueAsIntOr0(
			object value)
		{
			return GetValue(
				value?.ToString().ToInt(0));
		}


		public static string GetValueAsLongOrNULL(
			object value)
		{
			return GetValue(
				value?.ToString().ToLong());
		}


		public static string GetValueAsLongOr0(
			object value)
		{
			return GetValue(
				value?.ToString().ToLong(0));
		}


		public static string GetValueAsDoubleOrNULL(
			object value)
		{
			return GetValue(
				value?.ToString().ToDouble());
		}


		public static string GetValueAsDoubleOr0(
			object value)
		{
			return GetValue(
				value?.ToString().ToDouble(0));
		}


		public static string GetValueAsFloatOrNULL(
			object value)
		{
			return GetValue(
				value?.ToString().ToFloat());
		}


		public static string GetValueAsFloatOr0(
			object value)
		{
			return GetValue(
				value?.ToString().ToFloat(0));
		}


		public static string GetValueAsDecimalOrNULL(
			object value)
		{
			return GetValue(
				value?.ToString().ToDecimal());
		}


		public static string GetValueAsDecimalOr0(
			object value)
		{
			return GetValue(value.ToString().ToDecimal(0));
		}


		public static string GetValueAsString(
			string value)
		{
			return GetValue(value);
		}


		public static string GetValueAsBool(
			object value)
		{
			return GetValue((bool)value);
		}


		public static string GetValueAsDateTime(
			object value)
		{
			return GetValue(value.ToString().ToDateTime());
		}

	}

}