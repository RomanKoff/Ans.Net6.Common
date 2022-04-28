using System.Security.Cryptography;
using System.Text;

namespace Ans.Net6.Common
{

	// enum EncodingsEnum

	public enum EncodingsEnum
	{
		Utf8,
		Windows1251,
		Koi8r
	}


	// void CreateDirectoryExt(string path)
	// void DeleteDirectoryExt(string path)
	// void DeleteFileExt(string path)
	// string GetFileBegin(FileStream stream, int size = 255)
	// string GetFileBegin(string filename, int size = 255)
	// string GetFileSHA1(FileStream stream, byte[] salt)
	// string GetFileSHA1(FileStream stream, string salt)
	// string GetFileSHA1(FileStream stream)
	// string GetFileSHA1(string filename, byte[] salt)
	// string GetFileSHA1(string filename, string salt)
	// string GetCatalogName(int id)
	// string GetFileExtention(string filename, bool hasDot)
	// [Obsolete] string GetFileNameWithoutExtension(string filename)
	// string[] GetFilenameHalfs(string filename)
	// string GetSizeOfKB(long size)
	// string GetSizeOfKB(int size)
	// bool HasInvalidPathChars(string path)
	// bool HasInvalidFileNameChars(string fileName)
	// string FileRead(string filename, EncodingsEnum encoding = EncodingsEnum.Utf8)
	// void FileWrite(string filename, string content, EncodingsEnum encoding = EncodingsEnum.Utf8, FileMode mode = FileMode.Create)
	// Encoding GetEncoding(EncodingsEnum encoding)
	// bool IsFilesEqual(FileInfo file1, FileInfo file2)

	public static class SuppIO
	{

		public static void CreateDirectoryExt(
			string path)
		{
			while (!Directory.Exists(path))
				Directory.CreateDirectory(path);
		}


		public static void DeleteDirectoryExt(
			string path)
		{
			if (Directory.Exists(path))
				Directory.Delete(path, true);
		}


		public static void DeleteFileExt(
			string path)
		{
			if (File.Exists(path))
				File.Delete(path);
		}


		public static string GetFileBegin(
			FileStream stream,
			int size = 255)
		{
			byte[] buffer = new byte[size];
			_ = stream.Read(buffer, 0, size);
			return Convert.ToBase64String(buffer);
		}


		public static string GetFileBegin(
			string filename,
			int size = 255)
		{
			using var stream = new FileStream(
				filename, FileMode.Open, FileAccess.Read, FileShare.Read);
			return GetFileBegin(stream, size);
		}


		public static string GetFileSHA1(
			FileStream stream,
			byte[] salt)
		{
			using var alg = new HMACSHA1(salt);
			try
			{
				byte[] a1 = alg.ComputeHash(stream);
				return string.Join(
					"", a1.Select(x => x.ToString("x2"))); // Convert.ToBase64String(result);
			}
			finally { alg.Clear(); }
		}


		public static string GetFileSHA1(
			FileStream stream,
			string salt)
		{
			return GetFileSHA1(stream, Encoding.Unicode.GetBytes(salt));
		}


		public static string GetFileSHA1(
			FileStream stream)
		{
			byte[] const_bytes = Array.Empty<byte>();
			return GetFileSHA1(stream, const_bytes);
		}


		public static string GetFileSHA1(
			string filename,
			byte[] salt)
		{
			using var stream = new FileStream(
				filename, FileMode.Open, FileAccess.Read, FileShare.Read);
			return GetFileSHA1(stream, salt);
		}


		public static string GetFileSHA1(
			string filename,
			string salt)
		{
			return GetFileSHA1(filename, Encoding.Unicode.GetBytes(salt));
		}


		public static string GetCatalogName(
			int id)
		{
			return string.Format("{0:000/00/00}", id);
		}


		public static string GetFileExtention(
			string filename,
			bool hasDot)
		{
			string s1 = Path.GetExtension(filename).ToLower();
			return (hasDot)
				? s1 : (!string.IsNullOrEmpty(s1))
					? s1[1..] : s1;
			//int i1 = filename.LastIndexOf('.');
			//if (i1 == -1)
			//	return string.Empty;
			//string s1 = (hasDot)
			//	? filename[i1..]
			//	: filename[(i1 + 1)..];
			//return s1.ToLower();
		}


		[Obsolete("Use Path.GetFileNameWithoutExtension() method.")]
		public static string GetFileNameWithoutExtension(
			string filename)
		{
			return Path.GetFileNameWithoutExtension(filename);
			//int i1 = filename.LastIndexOf('.');
			//if (i1 == -1)
			//    return string.Empty;
			//return filename[..i1];
		}


		public static string[] GetFilenameHalfs(
			string filename)
		{
			int i1 = filename.LastIndexOf('.');
			if (i1 == -1)
				return new string[] { filename, string.Empty };
			return new string[] {
				filename[..i1],
				filename[(i1 + 1)..]
			};
		}


		public static string GetSizeOfKB(
			long size)
		{
			long l1 = 1;
			if (size >= 1024)
				l1 = (size + 511) / 1024;
			return l1.ToString(_Res.Format_SizeKB).TrimStart();
		}


		public static string GetSizeOfKB(
			int size)
		{
			return GetSizeOfKB((long)size);
		}


		public static bool HasInvalidPathChars(
			string path)
		{
			if (path == null)
				throw new ArgumentNullException(nameof(path));
			return path.IndexOfAny(Path.GetInvalidPathChars()) >= 0;
		}


		public static bool HasInvalidFileNameChars(
			string fileName)
		{
			if (fileName == null)
				throw new ArgumentNullException(nameof(fileName));
			return fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0;
		}


		public static string FileRead(
			string filename,
			EncodingsEnum encoding = EncodingsEnum.Utf8)
		{
			string result;
			var stream = new FileStream(
				filename, FileMode.Open, FileAccess.Read, FileShare.Read);
			using var reader = new StreamReader(stream, GetEncoding(encoding));
			result = reader.ReadToEnd();
			return result;
		}


		public static void FileWrite(
			string filename,
			string content,
			EncodingsEnum encoding = EncodingsEnum.Utf8,
			FileMode mode = FileMode.Create)
		{
			var stream = new FileStream(filename, mode);
			using var writer = new StreamWriter(stream, GetEncoding(encoding));
			writer.Write(content);
		}


		public static Encoding GetEncoding(
			EncodingsEnum encoding)
		{
			switch (encoding)
			{
				case EncodingsEnum.Windows1251:
					return _Const.ENCODING_WINDOWS1251;
				case EncodingsEnum.Koi8r:
					return _Const.ENCODING_KOI8R;
				default: break;
			}
			return _Const.ENCODING_UTF8;
		}


		public static bool IsFilesEqual(
			FileInfo file1,
			FileInfo file2)
		{
			if (file1.Length != file2.Length)
				return false;
			using var stream1 = file1.OpenRead();
			using var stream2 = file2.OpenRead();
			if (!SuppIO.GetFileBegin(stream1).Equals(SuppIO.GetFileBegin(stream2)))
				return false;
			if (!SuppIO.GetFileSHA1(stream1).Equals(SuppIO.GetFileSHA1(stream2)))
				return false;
			return true;
		}





		//public static string GetParentDir(
		//	string path)
		//	=> path.GetBackTo('\\', 1);

		//public static string GetSafeFilename(
		//	string filename)
		//{
		//	var a1 = GetFilenameHalfs(filename);
		//	var sb = new StringBuilder(a1[0].ToLower());
		//	sb.TranslitRuToEn();
		//	sb.TransformToSafeText();
		//	sb.ReplaceRecursively("__", "_");
		//	return string.Format("{0}.{1}",
		//		sb.ToString().GetCrop(0, 60, "~"), a1[1]);
		//}

	}

}
