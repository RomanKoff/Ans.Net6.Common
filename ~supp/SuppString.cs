using System.Text;

namespace Ans.Net6.Common
{

	// string Join(string templateResult, string templateItem, string itemsSeparator, params string[] data)
	// string Join(string templateResult, string templateItem, string itemsSeparator, string data, string dataSeparator)
	// KeyValuePair<string, string> GetPair(string definition, string separator)
	// KeyValuePair<string, string> GetPair(string definition)

	public static class SuppString
	{

		public static string Join(
			string templateResult,
			string templateItem,
			string itemsSeparator,
			params string[] data)
		{
			var sb = new StringBuilder();
			bool f1 = true;
			bool f2 = string.IsNullOrEmpty(templateItem);
			foreach (var s1 in data)
				if (!string.IsNullOrEmpty(s1))
				{
					if (f1)
						f1 = false;
					else
						sb.Append(itemsSeparator);
					sb.Append(f2 ? s1 : string.Format(templateItem, s1));
				}
			string s2 = sb.ToString();
			if (string.IsNullOrEmpty(s2))
				return string.Empty;
			return (string.IsNullOrEmpty(templateResult))
				? s2 : string.Format(templateResult, s2);
		}


		public static string Join(
			string templateResult,
			string templateItem,
			string itemsSeparator,
			string data,
			string dataSeparator)
		{
			return Join(
				templateResult, templateItem, itemsSeparator,
				data.Split(dataSeparator));
		}


		public static KeyValuePair<string, string> GetPair(
			string definition,
			string separator)
		{
			int i1 = definition.IndexOf(separator);
			if (i1 > 0)
				return new KeyValuePair<string, string>(
					definition[..i1],
					definition[(i1 + separator.Length)..]);
			return new KeyValuePair<string, string>(
				definition,
				definition);
		}


		public static KeyValuePair<string, string> GetPair(
			string definition)
		{
			return GetPair(definition, "=");
		}

	}

}
