using System.Globalization;

namespace Ans.Net6.Common
{

	// void SetCulture(CultureInfo culture)
	// void SetCulture(string culture)

	public static class SuppCulture
	{

		public static void SetCulture(
			CultureInfo culture)
		{
			Thread.CurrentThread.CurrentUICulture = culture;
			Thread.CurrentThread.CurrentCulture = CultureInfo
				.CreateSpecificCulture(culture.Name);
		}


		public static void SetCulture(
			string culture)
		{
			SetCulture(new CultureInfo(culture));
		}





		//public static void SetUserCulture(
		//	string culture = null)
		//{
		//	var context = HttpContext.Current;
		//	if (context.Session != null)
		//	{
		//		CultureInfo info = (CultureInfo)context
		//			.Session[_Const. CULTURE_SESSION_KEY];
		//		if (info == null)
		//		{
		//			string s1 = (context.Request.UserLanguages != null
		//				&& context.Request.UserLanguages.Any())
		//					? context.Request.UserLanguages[0].Substring(0, 2)
		//					: culture ?? _CONS.CULTURE_DEFAULT;
		//			info = new CultureInfo(s1);
		//			context.Session[_CONS.CULTURE_SESSION_KEY] = info;
		//		}
		//		SetCulture(info);
		//	}
		//}

	}

}
