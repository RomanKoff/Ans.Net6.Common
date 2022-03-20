namespace Ans.Net6.Common
{

	// string Convert_ISO88591_UTF8(this string source)
	// string Convert_WINDOWS1251_UTF8(this string source)
	// string Convert_KOI8R_UTF8(this string source)
	
	public static partial class _e
	{

		public static string Convert_ISO88591_UTF8(
			this string source)
		{
			return _Const.ENCODING_UTF8.GetString(
				_Const.ENCODING_ISO88591.GetBytes(
					source));
		}


		public static string Convert_WINDOWS1251_UTF8(
			this string source)
		{
			return _Const.ENCODING_UTF8.GetString(
				_Const.ENCODING_WINDOWS1251.GetBytes(
					source));
		}


		public static string Convert_KOI8R_UTF8(
			this string source)
		{
			return _Const.ENCODING_UTF8.GetString(
				_Const.ENCODING_KOI8R.GetBytes(
					source));
		}

	}

}
