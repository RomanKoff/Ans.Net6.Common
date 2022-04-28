using System.Security.Cryptography;
using System.Text;

namespace Ans.Net6.Common
{

	// int Next()
	// int Next(int max)
	// int Next(int min, int max)
	// string Generate(string mask, int minLength, int maxLength)
	// string Generate(string mask, int length)

	public static class SuppRandom
	{

		/// <summary>
		/// Возвращает случайное положительное целое число
		/// </summary>
		public static int Next()
		{
			using var generator = RandomNumberGenerator.Create();
			var a1 = new byte[4];
			generator.GetBytes(a1);
			return Math.Abs(BitConverter.ToInt32(a1, 0));
		}


		/// <summary>
		/// Возвращает случайное положительное целое число с учетом максимума
		/// </summary>
		public static int Next(
			int max)
		{
			return Next() % (max + 1);
		}


		/// <summary>
		/// Возвращает случайное положительное целое число с учетом максимума и минимума
		/// </summary>
		public static int Next(
			int min,
			int max)
		{
			return Next(max - min) + min;
		}


		/// <summary>
		/// Возвращает случайный текст
		/// </summary>
		public static string Generate(
			string mask,
			int minLength,
			int maxLength)
		{
			var a1 = mask.ToCharArray();
			int len = (minLength == maxLength)
				? minLength
				: Next(minLength, maxLength);
			var sb = new StringBuilder(len);
			for (int i1 = 0; i1 < len; i1++)
				sb.Append(a1[Next(a1.Length - 1)]);
			return sb.ToString();
		}


		/// <summary>
		/// Возвращает случайный текст
		/// </summary>
		public static string Generate(
			string mask,
			int length)
		{
			return Generate(mask, length, length);
		}

	}

}
