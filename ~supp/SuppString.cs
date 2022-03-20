using System.Collections.Generic;
using System.Text;

namespace Ans.Net6.Common
{

	public static class SuppString
	{

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


		public static string JoinNotEmpty(
			string template,
			string separator,
			params string[] parts)
		{
			var sb = new StringBuilder();
			bool f1 = true;
			foreach (string s1 in parts)
				if (!string.IsNullOrEmpty(s1))
				{
					if (f1)
						f1 = false;
					else
						sb.Append(separator);
					sb.Append(s1);
				}
			string s2 = sb.ToString();
			if (string.IsNullOrEmpty(s2))
				return string.Empty;
			if (string.IsNullOrEmpty(template))
				return s2;
			return string.Format(template, s2);
		}


		public static KeyValuePair<string, string> GetPair(
			string definition,
			string separator)
		{
			int i1 = definition.IndexOf(separator);
			if (i1 > 0)
				return new KeyValuePair<string, string>(
					definition.Substring(0, i1),
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
