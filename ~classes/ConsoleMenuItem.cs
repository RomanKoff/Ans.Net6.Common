using System;

namespace Ans.Net6.Common
{

	public class ConsoleMenuItem
	{
		public ConsoleKey Key { get; private set; }
		public string Title { get; private set; }
		public Action Method { get; private set; }

		public ConsoleMenuItem(
			ConsoleKey key,
			string title,
			Action method)
		{
			this.Key = key;
			this.Title = title;
			this.Method = method;
		}
	}

}
