using System.Text.RegularExpressions;

namespace Ans.Net6.Common
{

	public static class SuppRegex
	{

		/// <summary>
		/// Кодировка спецсимволов для regex-выражений
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string ParamEncode(
			string source)
		{
			return Regex.Replace(source, @"[]^\\-]", @"\$&");
		}

	}

}
