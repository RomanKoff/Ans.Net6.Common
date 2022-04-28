using System.Text;

namespace Ans.Net6.Common
{

	// void FixTextLine(this StringBuilder sb)
	// void FixTextBox(this StringBuilder sb)
	// void FixHtml(this StringBuilder sb)
	// void FixHtmlLine(this StringBuilder sb)
	// void FixHtmlBox(this StringBuilder sb)
	// string GetFixTextLine(this string source)
	// string GetFixTextBox(this string source)
	// string GetFixHtml(this string source)
	// string GetFixHtmlLine(this string source)
	// string GetFixHtmlBox(this string source)
	// string GetFixString(this string source)
	// string GetFixStringLo(this string source)
	// string GetFixStringName(this string source)

	public static partial class _e
	{

		public static void FixTextLine(
			this StringBuilder sb)
		{
			sb.ReplaceSpecChars();
			sb.ReplaceRecursively("  ", " ");
			sb.Trim(new char[] { ' ' });
		}


		public static void FixTextBox(
			this StringBuilder sb)
		{
			sb.Replace("\r", "");
			sb.ReplaceRecursively("  ", " ");
			sb.Replace(" \t", "\t");
			sb.Replace("\t ", "\t");
			sb.Replace(" \n", "\n");
			sb.Replace("\n ", "\n");
			sb.ReplaceRecursively("\n\n\n", "\n\n");
			sb.Trim(new char[] { '\n' });
		}


		public static void FixHtml(
			this StringBuilder sb)
		{
			sb.Replace("&amp;", "&");
			sb.Replace("&nbsp;", " ");
			sb.Replace("&gt;", ">");
			sb.Replace("&lt;", "<");
		}


		public static void FixHtmlLine(
			this StringBuilder sb)
		{
			sb.FixTextLine();
			sb.FixHtml();
		}


		public static void FixHtmlBox(
			this StringBuilder sb)
		{
			sb.FixTextBox();
			sb.FixHtml();
		}


		public static string GetFixTextLine(
			this string source)
		{
			if (string.IsNullOrEmpty(source))
				return string.Empty;
			var sb = new StringBuilder(source);
			sb.FixTextLine();
			return sb.ToString();
		}


		public static string GetFixTextBox(
			this string source)
		{
			if (string.IsNullOrEmpty(source))
				return string.Empty;
			var sb = new StringBuilder(source);
			sb.FixTextBox();
			return sb.ToString();
		}


		public static string GetFixHtml(
			this string source)
		{
			if (string.IsNullOrEmpty(source))
				return string.Empty;
			var sb = new StringBuilder(source);
			sb.FixHtml();
			return sb.ToString();
		}


		public static string GetFixHtmlLine(
			this string source)
		{
			if (string.IsNullOrEmpty(source))
				return string.Empty;
			var sb = new StringBuilder(source);
			sb.FixHtmlLine();
			return sb.ToString();
		}


		public static string GetFixHtmlBox(
			this string source)
		{
			if (string.IsNullOrEmpty(source))
				return string.Empty;
			var sb = new StringBuilder(source);
			sb.FixHtmlBox();
			return sb.ToString();
		}


		public static string GetFixString(
			this string source)
		{
			if (string.IsNullOrEmpty(source))
				return string.Empty;
			return source.Trim();
		}


		public static string GetFixStringLo(
			this string source)
			=> source.GetFixString().ToLower();


		public static string GetFixStringName(
			this string source)
		{
			var sb = new StringBuilder(source);
			sb.ReplaceSpecChars();
			sb.ReplaceRecursively("  ", " ");
			return sb
				.GetTransformToStartWithACapital()
				.ToString()
				.GetFixString();
		}





		//public static void Typography(
		//	this StringBuilder sb)
		//{
		//	sb.ReplaceRecursively("  ", " ");
		//	SuppHtml.ReplaceHtmlMacros(sb);
		//	_ = sb
		//		.Replace(" .", ".").Replace(" ,", ",")
		//		.Replace(" :", ":").Replace(" ;", ";")
		//		.Replace(" - ", " — ").Replace(" -", "-").Replace("- ", "-")
		//		.Replace("« ", "«").Replace(" »", "»")
		//		.Replace("” ", "”").Replace(" “", "“")
		//		.Replace("„ ", "„")
		//		.Replace("( ", "(").Replace(" )", ")")
		//		.Replace("[ ", "[").Replace(" ]", "]")
		//		.Replace(" …", "…");
		//}

		//public static string TypographLine(
		//	this string source)
		//{
		//	if (string.IsNullOrEmpty(source))
		//		return string.Empty;
		//	var sb = new StringBuilder(source);
		//	return FixString(sb.ToString());
		//}

		//public static string TypographBox(
		//	string source)
		//{
		//	if (string.IsNullOrEmpty(source))
		//		return string.Empty;
		//	var sb = new StringBuilder(source);
		//	return FixString(sb.ToString());
		//}

	}

}
