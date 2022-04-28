using Newtonsoft.Json;

namespace Ans.Net6.Common.Json
{

	public class BoolConverter
		: JsonConverter
	{
		public override bool CanConvert(
			Type objectType)
		{
			return false;
		}

		public override object ReadJson(
			JsonReader reader,
			Type objectType,
			object existingValue,
			JsonSerializer serializer)
		{
			return (reader.Value.ToString() == "1");
		}

		public override void WriteJson(
			JsonWriter writer,
			object value,
			JsonSerializer serializer)
		{
			writer.WriteValue(((bool)value) ? 1 : 0);
		}
	}



	public class DateTimeConverter
		: JsonConverter
	{
		public override bool CanConvert(
			Type objectType)
		{
			return false;
		}

		public override object ReadJson(
			JsonReader reader,
			Type objectType,
			object existingValue,
			JsonSerializer serializer)
		{
			var v1 = reader.Value.ToString().ToDouble(0);
			var d1 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			return d1.AddSeconds(v1);
		}

		public override void WriteJson(
			JsonWriter writer,
			object value,
			JsonSerializer serializer)
		{
			var v1 = (DateTime)value;
			var t1 = v1.ToUniversalTime()
				.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0));
			writer.WriteValue((long)Math.Truncate(t1.TotalSeconds));
		}
	}



	public class DateLiteConverter
		: JsonConverter
	{
		public override bool CanConvert(
			Type objectType)
		{
			return false;
		}

		public override object ReadJson(
			JsonReader reader,
			Type objectType,
			object existingValue,
			JsonSerializer serializer)
		{
			return reader.Value.ToString().ToDateTime(); ;
		}

		public override void WriteJson(
			JsonWriter writer,
			object value,
			JsonSerializer serializer)
		{
			writer.WriteValue(
				((DateTime)value).ToShortDateString());
		}
	}



	public enum Sample1Enum
	{
		TextValueDefault,
		TextValue1,
		TextValue2,
		TextValue3
	}
	
	
	
	public class Sample1EnumConverter
		: JsonConverter
	{
		public override bool CanConvert(Type objectType)
			=> false;

		public override object ReadJson(
			JsonReader reader,
			Type objectType,
			object existingValue,
			JsonSerializer serializer)
		{
			return reader.Value.ToString() switch
			{
				"value1" => Sample1Enum.TextValue1,
				"value2" => Sample1Enum.TextValue2,
				"value3" => Sample1Enum.TextValue3,
				_ => Sample1Enum.TextValueDefault
			};
		}

		public override void WriteJson(
			JsonWriter writer,
			object value,
			JsonSerializer serializer)
		{
			writer.WriteValue((Sample1Enum)value switch
			{
				Sample1Enum.TextValue1 => "value1",
				Sample1Enum.TextValue2 => "value2",
				Sample1Enum.TextValue3 => "value3",
				_ => "valueDefault"
			});
		}
	}



	public enum Sample2Enum
	{
		IntValueDefault,
		IntValue1,
		IntValue2,
		IntValue3
	}
	
	
	
	public class Sample2EnumConverter
		: JsonConverter
	{
		public override bool CanConvert(Type objectType)
			=> false;

		public override object ReadJson(
			JsonReader reader,
			Type objectType,
			object existingValue,
			JsonSerializer serializer)
		{
			return int.Parse(reader.Value.ToString()) switch
			{
				1 => Sample2Enum.IntValue1,
				2 => Sample2Enum.IntValue2,
				3 => Sample2Enum.IntValue3,
				_ => Sample2Enum.IntValueDefault
			};
		}

		public override void WriteJson(
			JsonWriter writer,
			object value,
			JsonSerializer serializer)
		{
			writer.WriteValue((Sample2Enum)value switch
			{
				Sample2Enum.IntValue1 => 1,
				Sample2Enum.IntValue2 => 2,
				Sample2Enum.IntValue3 => 3,
				_ => 0
			});
		}
	}

}
