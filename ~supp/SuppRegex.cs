using System.Text.RegularExpressions;

namespace Ans.Net6.Common
{

	public static class SuppRegex
	{

		public static string ParamEncode(
			string source)
		{
			return Regex.Replace(source, @"[]^\\-]", @"\$&");
		}

	}

}
