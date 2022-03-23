using System.Text;

namespace Ans.Net6.Common
{

	public class ParamsBuilder
	{
		public ParamsCollection Parameters { get; private set; }

		public ParamsBuilder()
		{
			this.Parameters = new ParamsCollection();
		}

		public void Add(
			string name,
			string value)
		{
			if (!string.IsNullOrEmpty(value))
				Parameters.Add(name, value);
		}

		public void Add(
			string name,
			bool value)
		{
			if (value)
				Parameters.Add(name, "1");
		}

		public void Add(
			string name,
			int value)
		{
			if (value != 0)
				Parameters.Add(name, value.ToString());
		}

		public void Add(
			string name,
			long value)
		{
			if (value != 0)
				Parameters.Add(name, value.ToString());
		}

		public void Add(
			string name,
			double value)
		{
			if (value != 0)
				Parameters.Add(name, value.ToString());
		}

		public void Add(
			string name,
			float value)
		{
			if (value != 0)
				Parameters.Add(name, value.ToString());
		}

		public void Add(
			string name,
			decimal value)
		{
			if (value != 0)
				Parameters.Add(name, value.ToString());
		}

		public void Add(
			string name,
			DateTime? value)
		{
			if (value != null)
				Parameters.Add(name, value.Value.ToString("u"));
		}

		public override string ToString()
		{
			return _toString(Parameters);
		}

		public string ToString(
			string name,
			string value)
		{
			var a1 = new ParamsCollection(Parameters.Count, Parameters.Comparer);
			foreach (var item in Parameters)
				a1.Add(item.Key, (string)item.Value.Clone());
			a1.SetParam(name, value);
			return _toString(a1);
		}

		public string ToString(
			string name,
			int value)
		{
			return ToString(name, value.ToString());
		}

		// privates

		private string _toString(
			ParamsCollection items)
		{
			if (!items.Any())
				return string.Empty;
			var sb = new StringBuilder();
			foreach (var item in items)
				sb.Append($"&{item.Key}={item.Value}");
			return $"?{sb.ToString()[1..]}";
		}
	}

}
