using System.Text;

namespace Ans.Net6.Common
{

	/// <summary>
	/// 
	/// </summary>
	public static class SuppString
	{

		/// <summary>
		/// 
		/// </summary>
		/// <param name="text1"></param>
		/// <param name="text2"></param>
		/// <param name="template"></param>
		/// <returns></returns>
		public static string Join2(
			string text1,
			string text2,
			string template)
		{
			if (string.IsNullOrEmpty(text1))
				return text2;
			if (string.IsNullOrEmpty(text2))
				return text1;
			return string.Format(template, text1, text2);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <param name="itemsSeparator"></param>
		/// <param name="templateItem"></param>
		/// <param name="templateResult"></param>
		/// <returns></returns>
		public static string Join(
			string[] data,
			string separator,
			string templateItem,
			string templateResult)
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
						sb.Append(separator);
					sb.Append(f2 ? s1 : string.Format(templateItem, s1));
				}
			string s2 = sb.ToString();
			if (string.IsNullOrEmpty(s2))
				return string.Empty;
			return (string.IsNullOrEmpty(templateResult))
				? s2 : string.Format(templateResult, s2);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <param name="dataSeparator"></param>
		/// <param name="itemsSeparator"></param>
		/// <param name="templateItem"></param>
		/// <param name="templateResult"></param>
		/// <returns></returns>
		public static string Join(
			string data,
			string dataSeparator,
			string itemsSeparator,
			string templateItem,
			string templateResult)
		{
			return Join(
				data.Split(dataSeparator),
				itemsSeparator, templateItem, templateResult);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="definition"></param>
		/// <param name="separator"></param>
		/// <returns></returns>
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


		/// <summary>
		/// 
		/// </summary>
		/// <param name="definition"></param>
		/// <returns></returns>
		public static KeyValuePair<string, string> GetPair(
			string definition)
		{
			return GetPair(definition, "=");
		}

	}

}
