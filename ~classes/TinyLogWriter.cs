using System.Text;

namespace Ans.Net6.Common
{

	public class TinyLogWriter
	{

		public string Filename { get; private set; }
		public int Length { get; set; }


		public TinyLogWriter(
			string filename,
			bool rewrite,
			int length = 300)
		{
			this.Filename = filename;
			this.Length = length;
			_init();
			if (rewrite)
				SuppIO.FileWrite(Filename, null);
		}


		public void Append(
			string text)
		{
			_sb.Append(text);
			_test();
		}


		public void Append(
			string template,
			params object[] args)
		{
			Append(string.Format(template, args));
		}


		public void AppendLine(
			string text)
		{
			_sb.AppendLine(text);
			_test();
		}


		public void AppendLine(
			string template,
			params object[] args)
		{
			AppendLine(string.Format(template, args));
		}


		public void AppendLog(
			string template,
			params object[] args)
		{
			string s1 = string.Format(template, args);
			Append(s1);
			Console.Write(s1);
		}


		public void AppendLineLog(
			string template,
			params object[] args)
		{
			string s1 = string.Format(template, args);
			AppendLine(s1);
			Console.WriteLine(s1);
		}


		public void Save()
		{
			SuppIO.FileWrite(Filename, _sb.ToString(), mode: FileMode.Append);
			_init();
		}



		// privates

		private StringBuilder _sb;
		private int _count;

		private void _init()
		{
			_sb = new StringBuilder();
			_count = 0;
		}

		private void _test()
		{
			_count++;
			if (_count > Length)
				Save();
		}

	}

}
