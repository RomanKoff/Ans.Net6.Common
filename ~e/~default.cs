namespace Ans.Net6.Common
{

	// string DefaultFor(this string target, string defaultValue)
	// void DefaultFor(this string value, ref string target)

	public static partial class _e
	{

		public static string DefaultFor(
			this string target,
			string defaultValue)
		{
			return (string.IsNullOrEmpty(target))
				? defaultValue
				: target;
		}


		public static void DefaultFor(
			this string value,
			ref string target)
		{
			if (string.IsNullOrEmpty(target))
				target = value;
		}

	}

}
