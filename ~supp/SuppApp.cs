using System.Reflection;

namespace Ans.Net6.Common
{

	/// <summary>
	/// string GetVersion()
	/// </summary>
	public static class SuppApp
	{

		public static string GetVersion()
		{
			return Assembly.GetEntryAssembly().GetName().Version.ToString();
		}

	}

}
