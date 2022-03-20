using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace Ans.Net6.Common
{

	public enum RegistryControlsEnum
	{
		Select,
		RadioLine,
		RadioBox,
	}



	public enum WidthsEnum
	{
		Full,
		ExtraLarge,
		Large,
		Medium,
		Small,
		ExtraSmall,
		Nothing
	}



	public delegate void RegistryItemEventHandler(object sender, RegistryItemEventArgs e);
	public class RegistryItemEventArgs : EventArgs
	{
		public RegistryItem Item { get; private set; }
		public RegistryItemEventArgs(RegistryItem item) { this.Item = item; }
	}



	public class Registry
		: List<RegistryItem>
	{

		public event RegistryItemEventHandler AddedItem;
		protected void OnAddedItem(RegistryItemEventArgs e) { AddedItem?.Invoke(this, e); }


		public Registry()
		{
		}


		public Registry(
			string source)
			: this()
		{
			this.FillFromString(source);
		}


		public Registry(
			params string[] source)
			: this()
		{
			this.FillFromString(source);
		}


		public Registry(
			string[] source,
			int firstIndex)
			: this()
		{
			foreach (string s1 in source)
				Add(firstIndex++, s1);
		}


		public Registry(
			IEnumerable items,
			string keyField,
			string fieldName)
			: this()
		{
			Type type = items.GetType().GetGenericArguments()[0];
			foreach (var item in items)
			{
				string key = item.GetPropertyValue(keyField, type).ToString();
				string value = (item.GetPropertyValue(fieldName, type)
					?? string.Empty).ToString();
				this.Add(key, value);
			}
		}


		public Registry(
			IEnumerable items,
			string keyField,
			string tempalte,
			params string[] fieldsNames)
			: this()
		{
			Type type = items.GetType().GetGenericArguments()[0];
			foreach (var item in items)
			{
				string key = item.GetPropertyValue(keyField, type).ToString();
				var values = fieldsNames
					.Select(x => item.GetPropertyValue(x, type))
					.ToArray();
				this.Add(key, string.Format(tempalte, values));
			}
		}


		public IEnumerable<RegistryItem> ItemsOnly
			=> this.Where(x => !x.IsLabel);


		public void Add(
			string key,
			string value,
			int level)
		{
			var item = new RegistryItem(key, value, level);
			this.Add(item);
			OnAddedItem(new RegistryItemEventArgs(item));
		}


		public void Add(
			int key,
			string value,
			int level)
		{
			this.Add(key.ToString(), value, level);
		}


		public void Add(
			string key,
			string value)
		{
			this.Add(key, value, 0);
		}


		public void Add(
			int key,
			string value)
		{
			this.Add(key.ToString(), value);
		}


		public void Add(
			string value)
		{
			this.Add(value, value);
		}


		public void AddNullItem(
			string emptyValue = null)
		{
			var item = new RegistryItem(
				emptyValue ?? string.Empty,				
				_Res.Text_NullItem);
			this.Insert(0, item);
			OnAddedItem(new RegistryItemEventArgs(item));
		}


		public void AddAllItems(
			string allValue = null)
		{
			var item = new RegistryItem(
				allValue ?? string.Empty,
				_Res.Text_AllItems);
			this.Insert(0, item);
			OnAddedItem(new RegistryItemEventArgs(item));
		}


		public void AddLabel(
			string title)
		{
			var item = new RegistryItem(0, title)
			{
				IsLabel = true
			};
			this.Add(item);
			OnAddedItem(new RegistryItemEventArgs(item));
		}


		/// <summary>
		/// Возвращает сериализацию реестра в виде строки
		/// "key1=value1;key2=value2;..." или
		/// "key1=level1:value1;key2=level2:value2;..."
		/// Символ ';' экранируется "\;"
		/// </summary>
		public override string ToString()
		{
			return string.Join(";", ItemsOnly.Select(x => x.ToString()));
		}


		/// <summary>
		/// Сериализация реестра из строки
		/// </summary>
		/// <param name="source">
		/// Строки пар значений реестра в виде "key1=value1", "key2=value2",...
		/// или "key1=level1:value1", "key2=level2:value2",...
		/// "!" — добавляет элемент «нулевое значение».
		/// "*" — добавляет элемент «все значения».
		/// Символ ';' экранируется "\;"
		/// </param>
		public void FillFromString(
			params string[] source)
		{
			this.Clear();
			if (source != null && source.Any())
			{
				bool hasNull = false;
				bool hasAll = false;
				foreach (var item1 in source)
					if (!hasNull && item1.Equals("!"))
					{
						this.AddNullItem();
						hasNull = true;
					}
					else if (!hasAll && item1.Equals("*"))
					{
						this.AddAllItems();
						hasAll = true;
					}
					else
					{
						var item2 = new RegistryItem();
						item2.FillFromString(item1);
						this.Add(item2);
					}
			}
		}


		/// <summary>
		/// Сериализация реестра из строки
		/// </summary>
		/// <param name="source">
		/// Строка сериализации реестра в виде "key1=value1;key2=value2;..."
		/// или "key1=level1:value1;key2=level2:value2;..."
		/// Символ ';' экранируется "\;"
		/// </param>
		public void FillFromString(
			string source)
		{
			FillFromString(source.SplitExt(";"));
		}


		/// <summary>
		/// Возвращает элемент по ключу
		/// </summary>
		public RegistryItem GetItem(
			string key)
		{
			return ItemsOnly
				.FirstOrDefault(x => x.Key.Equals(key));
		}


		/// <summary>
		/// Возвращает ключ по значению
		/// </summary>
		public string GetKey(
			string value)
		{
			var item = ItemsOnly
				.FirstOrDefault(x => x.Value.Equals(value));
			if (item != null)
				return item.Key;
			return null;
		}


		/// <summary>
		/// Возвращает ключ элемента.
		/// Если элемент отсутствует, то создает его
		/// </summary>
		public string GetKeyForValue(
			string value,
			string newKey = null)
		{
			var key = GetKey(value);
			if (key != null)
				return key;
			this.Add(newKey ?? this.Count.ToString(), value);
			return newKey;
		}


		/// <summary>
		/// Возвращает значение по ключу
		/// </summary>
		public string GetValue(
			string key)
		{
			var item = GetItem(key);
			if (item != null)
				return item.Value;
			return null;
		}


		/// <summary>
		/// Возвращает уровень в дереве по ключу
		/// </summary>
		public int GetLevel(
			string key)
		{
			var item = GetItem(key);
			if (item != null)
				return item.Level;
			return 0;
		}


		/// <summary>
		/// Возвращает уровень в дереве по ключу
		/// </summary>
		public int GetLevel(
			int key)
		{
			return GetLevel(key.ToString());
		}


		/// <summary>
		/// Возвращает уровень в дереве по ключу
		/// </summary>
		public int GetLevel(
			int? key)
		{
			return (key == null)
				? 0 : GetLevel(key.Value);
		}


		/// <summary>
		/// Возвращает значение если ключ содержит 'inclusion'
		/// </summary>
		public string GetValueInclusion(
			string inclusion)
		{
			var item = ItemsOnly
				.FirstOrDefault(x => x.Key.IndexOf(inclusion) > 0);
			if (item != null)
				return item.Value;
			return null;
		}


		/// <summary>
		/// Возвращает значение если 'expansion' содержит ключ
		/// </summary>
		public string GetValueExpansion(
			string expansion)
		{
			var item = ItemsOnly
				.FirstOrDefault(x => expansion.IndexOf(x.Key) > 0);
			if (item != null)
				return item.Value;
			return null;
		}


		/// <summary>
		/// Возвращает максимальную длину значения элемента реестра
		/// </summary>
		public int GetMaxWidth()
		{
			return ItemsOnly.Max(x => x.Value.Length);
		}


		/// <summary>
		/// Возвращает предложение по элементу ввода
		/// для отображение реестра
		/// </summary>
		public RegistryControlsEnum GetProposeControl(
			int count,
			int width)
		{
			if (width < 21 && count < 20)
				return RegistryControlsEnum.RadioLine;
			return (count < 30)
				? RegistryControlsEnum.RadioBox
				: RegistryControlsEnum.Select;
		}


		/// <summary>
		/// Возвращает предложение по элементу ввода
		/// для отображение реестра
		/// </summary>
		public RegistryControlsEnum GetProposeControl()
		{
			return this.GetProposeControl(
				this.Count, this.GetMaxWidth());
		}


		/// <summary>
		/// Возвращает предожение по ширине элемента ввода
		/// для отображение реестра
		/// </summary>
		public WidthsEnum GetProposeWidth(
			int width)
		{
			if (width < 11)
				return WidthsEnum.Small;
			if (width < 31)
				return WidthsEnum.Medium;
			if (width < 61)
				return WidthsEnum.Large;
			return WidthsEnum.Full;
		}


		/// <summary>
		/// Возвращает предожение по ширине элемента ввода
		/// для отображение реестра
		/// </summary>
		public WidthsEnum GetProposeWidth()
		{
			return GetProposeWidth(
				this.GetMaxWidth());
		}


		public void Localization(
			string source)
		{
			if (!string.IsNullOrEmpty(source))
			{
				var reg = new Registry(source);
				foreach (var item in ItemsOnly)
				{
					string value = reg.GetValue(item.Key);
					if (!string.IsNullOrEmpty(value))
						item.Value = value;
				}
			}
		}


		public void Localization(
			string key,
			ResourceManager manager,
			ResourceManager commonManager = null)
		{
			if (manager != null)
			{
				string s1 = manager.GetString(key);
				if (string.IsNullOrEmpty(s1) && commonManager != null)
					s1 = commonManager.GetString(key);
				Localization(s1);
			}
		}

	}

}
