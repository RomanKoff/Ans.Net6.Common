﻿namespace Ans.Net6.Common
{

	public class DateTimeHelper
	{

		/// <summary>
		/// текущая дата и время
		/// </summary>
		public DateTime Current { get; private set; }

		/// <summary>
		/// дата начала текущего года
		/// </summary>
		public DateTime CurrentYearBegin { get; private set; }

		/// <summary>
		/// дата начала следующего года
		/// </summary>
		public DateTime NextYearBegin { get; private set; }

		/// <summary>
		/// дата сегодня
		/// </summary>
		public DateTime Today { get; private set; }

		/// <summary>
		/// дата вчера
		/// </summary>
		public DateTime Yesterday { get; private set; }

		/// <summary>
		/// дата завтра
		/// </summary>
		public DateTime Tomorrow { get; private set; }

		/// <summary>
		/// дата послезавтра
		/// </summary>
		public DateTime TomorrowAfter { get; private set; }


		public DateTimeHelper()
		{
			this.Current = DateTime.Now;
			this.CurrentYearBegin = new DateTime(Current.Year, 1, 1);
			this.NextYearBegin = CurrentYearBegin.AddYears(1); 
			this.Today = Current.GetDateOnly();
			this.Yesterday = Today.AddDays(-1);
			this.Tomorrow = Today.AddDays(1);
			this.TomorrowAfter = Today.AddDays(2);			
		}


		/// <summary>
		/// Возвращает дату (и время) события (для блога)
		///	- будет в будущих годах
		///		d MMMM yyyy г.[ в H:mmmm] / MMMM d, yyyy[ at h:mmmm]
		///	- будет в этом году
		///		d MMMM[ в H:mmmm] / MMMM d[ at h:mmmm]
		///	- завтра
		///		завтра[ в H:mmmm] / Tomorrow[ at h:mmmm]
		///	- сегодня
		///		сегодня[ в H:mmmm] / Today[ at h:mmmm]
		///	- вчера
		///		вчера[ в H:mmmm] / Yesterday[ в H:mmmm]
		///	- было в этом году
		///		d MMMM[ в H:mmmm] / MMMM d[ at h:mmmm]
		///	- было в прошлые годы
		///		d MMMM yyyy г.[ в H:mmmm] / MMMM d, yyyy[ at h:mmmm]
		/// </summary>
		public string GetPassed(
			DateTime datetime,
			bool hasTime,
			bool allowYesterdayTodayTomorrow = true)
		{
			if (!datetime.HasTime())
				hasTime = false;
			// будет в будущих годах
			if (datetime >= NextYearBegin)
				return datetime.ToString((hasTime)
					? _Res.Format_DateTime_ForFull
					: _Res.Format_Date_ForFull);
			// будет в этом году
			if (allowYesterdayTodayTomorrow && datetime >= TomorrowAfter)
				return datetime.ToString((hasTime)
					? _Res.Format_DateTime_ForCurrentYear
					: _Res.Format_Date_ForCurrentYear);
			// завтра
			if (allowYesterdayTodayTomorrow && datetime >= Tomorrow)
				return datetime.ToString((hasTime)
					? _Res.Format_DateTime_ForTomorrow
					: _Res.Format_Date_ForTomorrow);
			// сегодня
			if (allowYesterdayTodayTomorrow && datetime >= Today)
				return datetime.ToString((hasTime)
					? _Res.Format_DateTime_ForToday
					: _Res.Format_Date_ForToday);
			// вчера
			if (allowYesterdayTodayTomorrow && datetime >= Yesterday)
				return datetime.ToString((hasTime)
					? _Res.Format_DateTime_ForYesterday
					: _Res.Format_Date_ForYesterday);
			// было в этом году
			if (datetime >= CurrentYearBegin)
				return datetime.ToString((hasTime)
					? _Res.Format_DateTime_ForCurrentYear
					: _Res.Format_Date_ForCurrentYear);
			// было в прошлые годы
			return datetime.ToString((hasTime)
				? _Res.Format_DateTime_ForFull
				: _Res.Format_Date_ForFull);
		}


		/// <summary>
		/// Возвращает дату (и время) прошедшего события (для блогов)
		/// </summary>
		public string GetPassed(
			DateTime? datetime,
			bool hasTime,
			bool allowYesterdayTodayTomorrow = true)
		{
			if (datetime == null)
				return _Res.Text_Never;
			return GetPassed(datetime.Value, hasTime, allowYesterdayTodayTomorrow);
		}


		/// <summary>
		/// Возвращает диапазон дат (для блога)
		/// - одна или равные даты
		/// - разные года
		/// - разные месяцы года
		/// - разные дни месяца
		/// </summary>
		public string GetSpan(
			DateTime date1,
			DateTime? date2,
			bool hideCurrentYear = true,
			bool allowYesterdayTodayTomorrow = false)
		{
			// одна или равные даты
			if (date2 == null || date1.Date.Equals(date2.Value.Date))
				return (hideCurrentYear)
					? GetPassed(date1, false, allowYesterdayTodayTomorrow)
					: date1.ToString(_Res.Format_DateRange_Full);
			DateTime d2 = date2.Value;
			if (date1 > d2)
				(date1, d2) = (d2, date1);
			if (date1.Year != d2.Year)
			{
				// разные года
				return string.Format("{0} – {1}",
					date1.ToString(_Res.Format_DateRange_Full),
					d2.ToString(_Res.Format_DateRange_Full));
			}
			if (date1.Month != d2.Month)
			{
				// разные месяцы года
				return string.Format("{0} – {1}",
					date1.ToString(_Res.Format_DateRange_WithinYear),
					(hideCurrentYear)
						? GetPassed(d2, false, allowYesterdayTodayTomorrow)
						: d2.ToString(_Res.Format_DateRange_Full));
			}
			// разные дни месяца
			return string.Format("{0}–{1}",
				date1.ToString(_Res.Format_DateRange_WithinMonth),
				(hideCurrentYear)
					? GetPassed(d2, false, allowYesterdayTodayTomorrow)
					: d2.ToString(_Res.Format_DateRange_Full));
		}

	}

}
