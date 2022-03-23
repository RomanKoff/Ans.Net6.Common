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



	public class ConsoleMenu
	{
		public List<ConsoleMenuItem> Items { get; private set; }
		public string Title { get; set; }
		public bool UseExit { get; set; }

		public ConsoleMenu(
			string title)
		{
			this.Items = new List<ConsoleMenuItem>();
			this.Title = title;
			this.UseExit = false;
		}

		public void Add(
			ConsoleMenuItem item)
		{
			this.Items.Add(item);
		}

		public void Release()
		{
			bool pressEscape = false;
			do
			{
				Console.WriteLine();
				if (!string.IsNullOrEmpty(Title))
					Console.WriteLine($"{Title}:");
				foreach (var item in Items)
					Console.WriteLine($"[{(char)item.Key}] — {item.Title}");
				Console.WriteLine(_Res.Text_PressEscToExit);
				Console.WriteLine();
				do
				{
					this.UseExit = false;
					var keyInfo = SuppConsole.ReadKey();
					foreach (var item in Items)
						if (item.Key == keyInfo.Key)
						{
							this.UseExit = true;
							item.Action();
						}
					pressEscape = keyInfo.Key == ConsoleKey.Escape;
				} while (!UseExit && !pressEscape);
			} while (!pressEscape);
		}
	}

}
