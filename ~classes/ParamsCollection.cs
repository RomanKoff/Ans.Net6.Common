using System.Runtime.Serialization;

namespace Ans.Net6.Common
{

	[Serializable]
	public class ParamsCollection
		: Dictionary<string, string>
	{

		protected ParamsCollection(
			SerializationInfo info,
			StreamingContext context)
			: base(info, context)
		{
		}


		public ParamsCollection()
			: base()
		{
		}


		public ParamsCollection(
			int capacity,
			IEqualityComparer<string> comparer)
			: base(capacity, comparer)
		{
		}


		public void SetParam(
			string name,
			string value)
		{
			if (this.ContainsKey(name))
				this[name] = value;
			else
				this.Add(name, value);
		}


		public void SetParamInt(
			string name,
			int value)
		{
			SetParam(name, value.ToString());
		}


		public void SetParamLong(
			string name,
			long value)
		{
			SetParam(name, value.ToString());
		}


		public void SetParamDouble(
			string name,
			double value)
		{
			SetParam(name, value.ToString());
		}


		public void SetParamFloat(
			string name,
			float value)
		{
			SetParam(name, value.ToString());
		}


		public void SetParamDecimal(
			string name,
			decimal value)
		{
			SetParam(name, value.ToString());
		}


		public void SetParamDataTime(
			string name,
			DateTime value)
		{
			SetParam(name, value.ToString());
		}

	}

}
