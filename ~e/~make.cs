using System.Text;

namespace Ans.Net6.Common
{

	// string Make(this string value, string template)
	// string Make(this string value, string template, string nullValue)
	// string Make(this int value, string template, string format = null, int? nullValue = null)
	// string Make(this int? value, string template, string format = null)
	// string Make(this long value, string template, string format = null, long? nullValue = null)
	// string Make(this long? value, string template, string format = null)
	// string Make(this double value, string template, string format = null, double? nullValue = null)
	// string Make(this double? value, string template, string format = null)
	// string Make(this float value, string template, string format = null, float? nullValue = null)
	// string Make(this float? value, string template, string format = null)
	// string Make(this decimal value, string template, string format = null, decimal? nullValue = null)
	// string Make(this decimal? value, string template, string format = null)
	// string Make(this DateTime value, string template, string format = null)
	// string Make(this DateTime? value, string template, string format = null, string emptyText = null)
	// string Make(this bool value, string trueText, string falseText = null)

	// string MakeIf(this bool expression, string template, params object[] args)
	// string MakeUseAddons(this string value, string template, params object[] addons)
	// string MakeRepeats(this string value, int count, string resultTemplate = null, string itemTemplate = null, string itemsSeparator = null)
	// string MakeFromCollection<T>(this IEnumerable<T> items, Func<T, string> itemExtractor, string resultTemplate, string itemTemplate, string itemsSeparator)
	// string MakeFromCollection(this IEnumerable<string> items, string resultTemplate, string itemTemplate, string itemsSeparator)
	// string MakeList(this string list, string resultTemplate, string itemTemplate, string itemsSeparator)
	// string MakeUrl(this string url, string template)

	// string Make_Passed(this DateTime datetime, DateTimeCalc calc, bool hasTime, bool allowYesterdayTodayTomorrow = true)
	// string Make_Passed(this DateTime? datetime, DateTimeCalc calc, bool hasTime, bool allowYesterdayTodayTomorrow = true)
	// string Make_Span(this DateTime date1, DateTime? date2, DateTimeCalc calc, bool hideCurrentYear = true, bool allowYesterdayTodayTomorrow = false)
	// string Make_SizeOfKB(this long size)
	// string Make_SizeOfKB(this int size)

	public static partial class _e
	{

		public static string Make(
			this string value,
			string template)
		{
			return (string.IsNullOrEmpty(value))
				? string.Empty
				: string.IsNullOrEmpty(template)
					? value
					: string.Format(template, value);
		}


		public static string Make(
			this string value,
			string template,
			string nullValue)
		{
			return value.Equals(nullValue)
				? string.Empty
				: string.Format(template, value);
		}


		public static string Make(
			this int value,
			string template,
			string format = null,
			int? nullValue = null)
		{
			return nullValue != null && value == nullValue
				? string.Empty
				: (string.IsNullOrEmpty(format)
					? value.ToString()
					: value.ToString(format))
						.Make(template);
		}


		public static string Make(
			this int? value,
			string template,
			string format = null)
		{
			return value == null
				? string.Empty
				: value.Value.Make(template, format);
		}


		public static string Make(
			this long value,
			string template,
			string format = null,
			long? nullValue = null)
		{
			return nullValue != null && value == nullValue
				? string.Empty
				: (string.IsNullOrEmpty(format)
					? value.ToString()
					: value.ToString(format))
						.Make(template);
		}


		public static string Make(
			this long? value,
			string template,
			string format = null)
		{
			return value == null
				? string.Empty
				: value.Value.Make(template, format);
		}


		public static string Make(
			this double value,
			string template,
			string format = null,
			double? nullValue = null)
		{
			return nullValue != null && value == nullValue
				? string.Empty
				: (string.IsNullOrEmpty(format)
					? value.ToString()
					: value.ToString(format))
						.Make(template);
		}


		public static string Make(
			this double? value,
			string template,
			string format = null)
		{
			return value == null
				? string.Empty
				: value.Value.Make(template, format);
		}


		public static string Make(
			this float value,
			string template,
			string format = null,
			float? nullValue = null)
		{
			return nullValue != null && value == nullValue
				? string.Empty
				: (string.IsNullOrEmpty(format)
					? value.ToString()
					: value.ToString(format))
						.Make(template);
		}


		public static string Make(
			this float? value,
			string template,
			string format = null)
		{
			return value == null
				? string.Empty
				: value.Value.Make(template, format);
		}


		public static string Make(
			this decimal value,
			string template,
			string format = null,
			decimal? nullValue = null)
		{
			return nullValue != null && value == nullValue
				? string.Empty
				: (string.IsNullOrEmpty(format)
					? value.ToString()
					: value.ToString(format))
						.Make(template);
		}


		public static string Make(
			this decimal? value,
			string template,
			string format = null)
		{
			return value == null
				? string.Empty
				: value.Value.Make(template, format);
		}


		public static string Make(
			this DateTime value,
			string template,
			string format = null)
		{
			return (string.IsNullOrEmpty(format)
				? value.ToString("d")
				: value.ToString(format))
					.Make(template);
		}


		public static string Make(
			this DateTime? value,
			string template,
			string format = null,
			string emptyText = null)
		{
			return value == null
				? emptyText ?? string.Empty
				: value.Value.Make(template, format);
		}


		public static string Make(
			this bool value,
			string trueText,
			string falseText = null)
		{
			if (value)
				return trueText;
			return falseText ?? string.Empty;
		}


		public static string MakeIf(
			this bool expression,
			string template,
			params object[] args)
		{
			if (expression)
				return string.Format(template, args);
			return string.Empty;
		}


		public static string MakeUseAddons(
			this string value,
			string template,
			params object[] addons)
		{
			if (string.IsNullOrEmpty(value))
				return string.Empty;
			return string.IsNullOrEmpty(template)
				? value
				: string.Format(template, addons.Insert(0, value));
		}


		public static string MakeRepeats(
			this string value,
			int count,
			string resultTemplate = null,
			string itemTemplate = null,
			string itemsSeparator = null)
		{
			if (string.IsNullOrEmpty(value) || count < 1)
				return string.Empty;
			string s1 = value.Make(itemTemplate);
			var sb = new StringBuilder();
			bool f1 = !string.IsNullOrEmpty(itemsSeparator);
			bool f2 = false;
			for (int i1 = 0; i1 < count; i1++)
			{
				if (f1)
				{
					if (f2)
						sb.Append(itemsSeparator);
					else
						f2 = true;
				}
				sb.Append(s1);
			}
			return sb.ToString().Make(resultTemplate);
		}


		public static string MakeFromCollection<T>(
			this IEnumerable<T> items,
			Func<T, string> itemExtractor,
			string resultTemplate,
			string itemTemplate,
			string itemsSeparator)
		{
			if (items == null || !items.Any())
				return string.Empty;
			var sb = new StringBuilder();
			bool f1 = !string.IsNullOrEmpty(itemsSeparator);
			bool f2 = false;
			string s1 = itemTemplate ?? "{0}";
			foreach (var item in items)
			{
				if (f1)
				{
					if (f2)
						sb.Append(itemsSeparator);
					else
						f2 = true;
				}
				sb.AppendFormat(s1, itemExtractor(item));
			}
			return sb.ToString().Make(resultTemplate);
		}


		public static string MakeFromCollection(
			this IEnumerable<string> items,
			string resultTemplate,
			string itemTemplate,
			string itemsSeparator)
		{
			return items.MakeFromCollection(
				x => x,
				resultTemplate,
				itemTemplate,
				itemsSeparator);
		}


		public static string MakeList(
			this string list,
			string resultTemplate,
			string itemTemplate,
			string itemsSeparator)
		{
			return list.SplitItems().MakeFromCollection(
				x => x,
				resultTemplate,
				itemTemplate,
				itemsSeparator);
		}


		public static string MakeUrl(
			this string url,
			string template)
		{
			if (string.IsNullOrEmpty(url))
				return string.Empty;
			if (url[0] == '/'
				|| url.StartsWith("https://")
				|| url.StartsWith("http://"))
				return url.Make(template);
			return string.Concat("https://", url).Make(template);
		}


		public static string Make_Passed(
			this DateTime datetime,
			DateTimeHelper calc,
			bool hasTime,
			bool allowYesterdayTodayTomorrow = true)
			=> calc.GetPassed(
				datetime, hasTime, allowYesterdayTodayTomorrow);


		public static string Make_Passed(
			this DateTime? datetime,
			DateTimeHelper calc,
			bool hasTime,
			bool allowYesterdayTodayTomorrow = true)
			=> calc.GetPassed(
				datetime, hasTime, allowYesterdayTodayTomorrow);


		public static string Make_Span(
			this DateTime date1,
			DateTime? date2,
			DateTimeHelper calc,
			bool hideCurrentYear = true,
			bool allowYesterdayTodayTomorrow = false)
			=> calc.GetSpan(
				date1, date2, hideCurrentYear, allowYesterdayTodayTomorrow);


		public static string Make_SizeOfKB(
			this long size)
			=> SuppIO.GetSizeOfKB(size);


		public static string Make_SizeOfKB(
			this int size)
			=> ((long)size).Make_SizeOfKB();


		//public static string MakeFromRegistry(
		//	this string value,
		//	Registry registry,
		//	string template = null,
		//	string nullValue = null)
		//{
		//	if (string.IsNullOrEmpty(value) || value == nullValue)
		//		return res_Common.Text_NullItem;
		//	return SuppMake.MakeFromRegistry(value, registry, template);
		//}

		//public static string MakeFromRegistry(
		//	string value,
		//	Registry registry,
		//	string template)
		//{
		//	if (registry == null)
		//		return "{" + value + "}";
		//	var item = registry.GetItem(value);
		//	return (item == null)
		//		? res_Common.Text_ErrorItem
		//		: Make(item.Value, template);
		//}

	}

}
