using System;

namespace Ans.Net6.Common
{

	/// <summary>
	/// Tiny Timer
	/// </summary>
	public class TinyTimer
	{
		/// <summary>
		/// Span
		/// </summary>
		public TimeSpan Span { get; set; }

		/// <summary>
		/// NextStop
		/// </summary>
		public DateTime NextStop { get; set; }

		/// <summary>
		/// UseEqualIntervals
		/// </summary>
		public bool UseEqualIntervals { get; set; }


		/// <summary>
		/// ctor: TinyTimer
		/// </summary>
		public TinyTimer(
			TimeSpan span,
			bool useEqualIntervals)
		{
			Span = span;
			NextStop = DateTime.Now + Span;
			UseEqualIntervals = useEqualIntervals;
		}


		/// <summary>
		/// Test
		/// </summary>
		public bool Test()
		{
			if (NextStop < DateTime.Now)
			{
				NextStop = (UseEqualIntervals)
					? NextStop + Span
					: DateTime.Now + Span;
				return true;
			}
			return false;
		}

	}

}
