using System.Reflection;

namespace Ans.Net6.Common
{

	// string GetVersion()

	public static class SuppApp
	{

		/// <summary>
		/// Возвращает версию сборки
		/// </summary>
		public static string GetVersion()
		{
			return Assembly.GetEntryAssembly().GetName().Version.ToString();
		}

	}

}
