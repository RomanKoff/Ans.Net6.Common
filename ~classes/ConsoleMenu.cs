using System;
using System.Collections.Generic;

namespace Ans.Net6.Common
{

	// var menu = new ConsoleMenu("Title");
	// menu.Add(System.ConsoleKey.D1, "Action 1", Action1);
	// menu.Release();

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

		public void Add(
			ConsoleKey key,
			string title,
			Action method)
		{
			Add(new ConsoleMenuItem(key, title, method));
		}

		public void Release()
		{
			bool pressEscape;
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
							item.Method();
						}
					pressEscape = keyInfo.Key == ConsoleKey.Escape;
				} while (!UseExit && !pressEscape);
			} while (!pressEscape);
		}
	}

}
