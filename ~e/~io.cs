using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ans.Net6.Common
{

	// IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo directoryInfo, params string[] extensions)
	// IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo directoryInfo, string extensions)

	public static partial class _e
	{

		public static IEnumerable<FileInfo> GetFilesByExtensions(
			this DirectoryInfo directoryInfo,
			params string[] extensions)
		{
			if (extensions == null)
				throw new ArgumentNullException(nameof(extensions));
			IEnumerable<FileInfo> files = directoryInfo.EnumerateFiles();
			return files.Where(f => extensions.Contains(f.Extension));
		}


		public static IEnumerable<FileInfo> GetFilesByExtensions(
			this DirectoryInfo directoryInfo,
			string extensions)
		{
			return GetFilesByExtensions(
				directoryInfo,
				extensions.Split(new char[] { ';', ',' }));
		}


		public static void MoveToSmart(
			this FileInfo fileInfo,
			string destFileName)
		{
			if (File.Exists(destFileName))
			{

			}
			else
			{
				fileInfo.MoveTo(destFileName);
			}
		}

	}

}
