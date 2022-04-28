namespace Ans.Net6.Common
{

	// T[] Insert&lt;T>(this T[] items, int index, T item)
	// T[] RemoveAt&lt;T>(this T[] items, int index)
	// T DefaultObject&lt;T>(this object value, T defaultValue)
	// T DefaultObject&lt;T>(this object value)
	// object GetPropertyValue(this object obj, string name, Type type)
	// object GetPropertyValue(this object obj, string name)
	// T GetPropertyValue&lt;T>(this object obj, string name, Type type)
	// T GetPropertyValue&lt;T>(this object obj, string name)

	public static partial class _e
	{

		public static T[] Insert<T>(
			this T[] items,
			int index,
			T item)
		{
			var a1 = items.ToList();
			if (index < 0)
				a1.Add(item);
			else
				a1.Insert(index, item);
			return a1.ToArray();
		}


		public static T[] RemoveAt<T>(
			this T[] items,
			int index)
		{
			var a1 = items.ToList();
			a1.RemoveAt(index);
			return a1.ToArray();
		}


		public static T DefaultObject<T>(
			this object value,
			T defaultValue)
		{
			if (value == null)
				return defaultValue;
			return (T)value;
		}


		public static T DefaultObject<T>(
			this object value)
		{
			return value.DefaultObject<T>(default);
		}


		public static object GetPropertyValue(
			this object obj,
			string name,
			Type type)
		{
			return type.GetProperty(name).GetValue(obj, null);
		}


		public static object GetPropertyValue(
			this object obj,
			string name)
		{
			return obj.GetPropertyValue(name, obj.GetType());
		}


		public static T GetPropertyValue<T>(
			this object obj,
			string name,
			Type type)
		{
			return (T)obj.GetPropertyValue(name, type);
		}


		public static T GetPropertyValue<T>(
			this object obj,
			string name)
		{
			return (T)obj.GetPropertyValue(name);
		}

	}

}
