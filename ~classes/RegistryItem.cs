namespace Ans.Net6.Common
{

	public class RegistryItem
	{

		public string Key { get; set; }
		public string Value { get; set; }
		public int Level { get; set; }
		public bool IsLabel { get; set; }


		public RegistryItem()
		{
		}


		public RegistryItem(
			string key,
			string value,
			int level)
			: this()
		{
			this.Key = key;
			this.Value = value;
			this.Level = level;
		}


		public RegistryItem(
			int key,
			string value,
			int level)
			: this(key.ToString(), value, level)
		{
		}


		public RegistryItem(
			string key,
			string value)
			: this(key, value, 0)
		{
		}


		public RegistryItem(
			int key,
			string value)
			: this(key, value, 0)
		{
		}


		public string ValueSafe
		{
			get => Value?.Replace(";", "\\;");
			set => this.Value = value.Replace("\\;", ";");
		}


		/// <summary>
		/// Возвращает сериализацию элемента в виде строки
		/// "key=value" или "key=level:value".
		/// Символ ';' экранируется "\;"
		/// </summary>
		public override string ToString()
		{
			if (string.IsNullOrEmpty(this.Key))
				return string.Empty;
			if (this.Level > 0)
				return string.Format("{0}={1}:{2}",
					this.Key, this.Level, this.ValueSafe);
			return string.Format("{0}={1}",
				this.Key, this.ValueSafe);
		}


		/// <summary>
		/// Десериализация элемента из строки вида
		/// "key=value" или "key=level:value"
		/// Символ ';' экранируется "\;"
		/// </summary>
		public void FillFromString(
			string source)
		{
			if (string.IsNullOrEmpty(source))
			{
				this.Key = string.Empty;
				this.Value = string.Empty;
				this.Level = 0;
			}
			else
			{
				int p1 = source.IndexOf('=');
				if (p1 > 0)
				{
					this.Key = source[..p1];
					string v1 = source[(p1 + 1)..];
					p1 = v1.IndexOf(':');
					if (p1 > 0)
					{
						this.ValueSafe = v1[(p1 + 1)..];
						this.Level = v1[..p1].ToInt(0);
					}
					else
					{
						this.ValueSafe = v1;
						this.Level = 0;
					}
				}
				else
				{
					this.Key = source;
					this.ValueSafe = source;
					this.Level = 0;
				}
			}
		}

	}

}
