namespace Ans.Net6.Common
{

	public static partial class _e
	{

		/// <summary>
		/// Сравнивает значения даты и времени с точностью minutesDiff
		/// </summary>
		/// <param name="datetime1"></param>
		/// <param name="datetime2"></param>
		/// <param name="minutesDiff"></param>
		/// <returns></returns>
		public static bool IsEqual(
			this DateTime datetime1,
			DateTime datetime2,
			int minutesDiff)
		{
			return (Math.Abs((datetime1 - datetime2).TotalMinutes) < minutesDiff);
		}


		/// <summary>
		/// Определяет наличие данных о времени
		/// </summary>
		/// <param name="datetime"></param>
		/// <returns></returns>
		public static bool HasTime(
			this DateTime datetime)
		{
			return !((datetime.Hour == 0) && (datetime.Minute == 0));
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="datetime"></param>
		/// <returns></returns>
		public static DateTime GetDateOnly(
			this DateTime datetime)
		{
			return datetime.Date;
		}


		/// <summary>
		/// Возвращает значение даты в виде строки в безопасном формате (yyyy-0MM-dd)
		/// </summary>
		/// <param name="datetime"></param>
		/// <returns></returns>
		public static string GetSafeDate(
			this DateTime datetime)
		{
			return datetime.ToString(
				_Const.FORMAT_SAFE_DATE);
		}


		/// <summary>
		/// Возвращает значение даты и времени в виде строки в безопасном формате (yyyy-0MM-dd HH:mmmm:ss)
		/// </summary>
		/// <param name="datetime"></param>
		/// <returns></returns>
		public static string GetSafeDateTime(
			this DateTime datetime)
		{
			return datetime.ToString(
				_Const.FORMAT_SAFE_DATETIME);
		}


		/// <summary>
		/// Возвращает значение даты и времени в виде строки в безопасном формате (yyyy-0MM-dd_HH:mmmm:ss) для именования файлов
		/// </summary>
		/// <param name="datetime"></param>
		/// <returns></returns>
		public static string GetSafeDateTimeForFile(
			this DateTime datetime)
		{
			return datetime.ToString(
				_Const.FORMAT_SAFE_DATETIME_FILE);
		}


		/// <summary>
		/// Возвращает значение даты и времени в виде строки в безопасном формате (yyyy0MMddHHmmmmss) минимальной длины
		/// </summary>
		/// <param name="datetime"></param>
		/// <returns></returns>
		public static string GetSafeDateTimeForMin(
			this DateTime datetime)
		{
			return datetime.ToString(
				_Const.FORMAT_SAFE_DATETIME_MIN);
		}

	}

}
