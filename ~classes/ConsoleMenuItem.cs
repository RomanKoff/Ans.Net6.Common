namespace Ans.Net6.Common
{

	public class ConsoleMenuItem
	{
		public ConsoleKey Key { get; private set; }
		public string Title { get; private set; }
		public Action Action { get; private set; }

		public ConsoleMenuItem(
			ConsoleKey key,
			string title,
			Action action)
		{
			this.Key = key;
			this.Title = title;
			this.Action = action;
		}
	}

}
