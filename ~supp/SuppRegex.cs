using System.Text.RegularExpressions;

namespace Ans.Net6.Common
{

	// string ParamEncode(string source)

	public static class SuppRegex
	{

		/// <summary>
		/// Кодировка спецсимволов для regex-выражений
		/// </summary>
		public static string ParamEncode(
			string source)
		{
			return Regex.Replace(source, @"[]^\\-]", @"\$&");
		}

	}

}
