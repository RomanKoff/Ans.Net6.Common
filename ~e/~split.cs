using System.Text;

namespace Ans.Net6.Common
{

	// IEnumerable<string> Trim(this IEnumerable<string> source)
	// IEnumerable<string> RemoveEmpty(this IEnumerable<string> source)
	// string[] SplitExt(this string source, string separator)
	// string[] SplitExt(this string source, int count, string separator)
	// string[] SplitExtW(this string source, string separator)
	// string[] SplitExtW(this string source, int count, string separator)	

	public static partial class _e
	{

		public static IEnumerable<string> Trim(
			this IEnumerable<string> source)
		{
			return source.Select(
				x => x.Trim());
		}


		public static IEnumerable<string> RemoveEmpty(
			this IEnumerable<string> source)
		{
			return source.Where(
				x => !string.IsNullOrEmpty(x));
		}


		/// <summary>
		/// Возвращает строковый массив, содержащий подстроки данной строки, разделенные сепаратором. Сепаратор экранируется '\'
		/// </summary>
		public static string[] SplitExt(
			this string source,
			string separator)
		{
			if (string.IsNullOrEmpty(source))
				return null;
			return _split(
				source.GetScreening(separator), separator);
		}


		/// <summary>
		/// Возвращает строковый массив размерностью 'upperIndex' содержащий подстроки исходной строки, разделенные сепаратором. Сепаратор экранируется '\'
		/// </summary>
		public static string[] SplitExt(
			this string source,
			int count,
			string separator)
		{
			return _split(
				source.GetScreening(separator), count, separator);
		}


		/// <summary>
		/// Возвращает строковый массив, содержащий подстроки данной строки, разделенные сепаратором. Сепаратор экранируется дублированием
		/// </summary>
		public static string[] SplitExtW(
			this string source,
			string separator)
		{
			if (string.IsNullOrEmpty(source))
				return null;
			return _split(
				source.GetScreeningW(separator), separator);
		}


		/// <summary>
		/// Возвращает строковый массив размерностью 'upperIndex' содержащий подстроки исходной строки, разделенные сепаратором. Сепаратор экранируется дублированием
		/// </summary>
		public static string[] SplitExtW(
			this string source,
			int count,
			string separator)
		{
			return _split(
				source.GetScreeningW(separator), count, separator);
		}



		// privates

		private static string[] _split(
			string sourceMasked,
			string separator)
		{
			var a1 = sourceMasked.Split(
				new string[] { separator }, StringSplitOptions.None);
			for (int i1 = 0; i1 < a1.GetUpperBound(0); i1++)
				a1[i1] = a1[i1].GetReScreening(separator);
			return a1;
		}

		private static string[] _split(
			string maskedSource,
			int count,
			string separator)
		{
			var a1 = new string[count];
			int c1 = 0;
			var sb = new StringBuilder();
			if (!string.IsNullOrEmpty(maskedSource))
			{
				var a2 = maskedSource.SplitExt(separator);
				if (a2 != null)
				{
					c1 = a2.GetUpperBound(0) + 1;
					if (c1 > count)
					{
						for (int i1 = count; i1 < c1; i1++)
							sb.Append(separator + a2[i1]);
						c1 = count;
					}
					for (int i1 = 0; i1 < c1; i1++)
						a1[i1] = a2[i1].GetReScreening(separator);
				}
			}
			for (int i1 = c1; i1 < count; i1++)
				a1[i1] = string.Empty;
			a1[count - 1] += sb.ToString();
			return a1;
		}





		///// <summary>
		///// Возвращает строковый массив, содержащий подстроки данной строки,
		///// разделенные сепаратором "," или ";"
		///// </summary>
		//public static string[] SplitItems(
		//	this string source)
		//{
		//	if (string.IsNullOrEmpty(source))
		//		return null;
		//	return source.Split(_Const.SPLIT_ITEMS);
		//}

		///// <summary>
		///// Возвращает строковый массив, содержащий подстроки данной строки,
		///// разделенные сепаратором |
		///// </summary>
		//public static string[] SplitVLine(
		//	this string source)
		//{
		//	if (string.IsNullOrEmpty(source))
		//		return null;
		//	return source.Split(_Const.SPLIT_VLINE);
		//}

		///// <summary>
		///// Возвращает строковый массив, содержащий подстроки данной строки,
		///// разделенные переводом строки (10)
		///// </summary>
		//public static string[] SplitLn(
		//	this string source)
		//{
		//	if (string.IsNullOrEmpty(source))
		//		return null;
		//	var a1 = source.Split(
		//		_Const.SPLIT_LN, StringSplitOptions.None);
		//	return a1.Select(x => x.Trim()).ToArray();
		//}

		///// <summary>
		///// Возвращает строковый массив, содержащий подстроки данной строки,
		///// разделенные сепаратором "|" или "="
		///// </summary>
		//public static string[] SplitParams(
		//	this string source)
		//{
		//	if (string.IsNullOrEmpty(source))
		//		return null;
		//	var a1 = source.Split(
		//		_Const.SPLIT_PARAMS, StringSplitOptions.None);
		//	return a1.Select(x => x.Trim()).ToArray();
		//}

		///// <summary>
		///// Возвращает строковый массив размерностью itemCount,
		///// содержащий подстроки данной строки,
		///// разделенные сепаратором " | "
		///// </summary>
		//public static string[] SplitData(
		//	this string source,
		//	int count)
		//{
		//	return source.SplitExt(count, " | ");
		//}

	}

}