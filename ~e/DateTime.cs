using System;

namespace Ans.Net6.Common
{

	public static partial class _e
	{

		/// <summary>
		/// Сравнивает значения даты и времени с точностью minutesDiff
		/// </summary>
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
		public static bool HasTime(
			this DateTime datetime)
		{
			return !((datetime.Hour == 0) && (datetime.Minute == 0));
		}


		public static DateTime GetDateOnly(
			this DateTime datetime)
		{
			return datetime.Date;
		}


		/// <summary>
		/// Возвращает значение даты в виде строки
		/// в безопасном формате (yyyy-0MM-dd)
		/// </summary>
		public static string GetSafeDate(
			this DateTime datetime)
		{
			return datetime.ToString(
				_Const.FORMAT_SAFE_DATE);
		}


		/// <summary>
		/// Возвращает значение даты и времени в виде строки
		/// в безопасном формате (yyyy-0MM-dd HH:mmmm:ss)
		/// </summary>
		public static string GetSafeDateTime(
			this DateTime datetime)
		{
			return datetime.ToString(
				_Const.FORMAT_SAFE_DATETIME);
		}


		/// <summary>
		/// Возвращает значение даты и времени в виде строки
		/// в безопасном формате (yyyy-0MM-dd_HH:mmmm:ss)
		/// для именования файлов
		/// </summary>
		public static string GetSafeDateTimeForFile(
			this DateTime datetime)
		{
			return datetime.ToString(
				_Const.FORMAT_SAFE_DATETIME_FILE);
		}


		/// <summary>
		/// Возвращает значение даты и времени в виде строки
		/// в безопасном формате (yyyy0MMddHHmmmmss)
		/// минимальной длины
		/// </summary>
		public static string GetSafeDateTimeForMin(
			this DateTime datetime)
		{
			return datetime.ToString(
				_Const.FORMAT_SAFE_DATETIME_MIN);
		}

	}

}
