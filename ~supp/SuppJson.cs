using Newtonsoft.Json;
using System.Text;

namespace Ans.Net6.Common
{

	/// <summary>
	/// </summary>
	public static class SuppJson
	{

		/// <summary>
		/// Отладка json объекта
		/// </summary>
		public static string GetDebugJsonHtml(
			object obj)
		{
			var sb = new StringBuilder();
			string s1 = GetJsonStringFromObject(obj);
			sb.AppendLine($"<h3>{obj.GetType().FullName}</h3>");
			sb.AppendLine("<pre><code class=\"language-html line-numbers\">");
			sb.AppendLine(SuppHtml.GetEscapeHtml(s1));
			sb.AppendLine("</code></pre>");
			return sb.ToString();
		}


		/// <summary>
		/// Возвращает строку json из объекта
		/// </summary>
		public static string GetJsonStringFromObject(
			object obj,
			JsonSerializerSettings settings = null)
		{
			return JsonConvert.SerializeObject(obj,
				settings ?? new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					Formatting = Formatting.None,
				});
		}


		/// <summary>
		/// Возвращает объект типа T из строки json
		/// </summary>
		public static T GetObjectFromJson<T>(
			string json)
		{
			return JsonConvert.DeserializeObject<T>(json);
		}


		/// <summary>
		/// Возвращает объект типа T из потока json
		/// </summary>
		public static T GetObjectFromJson<T>(
			Stream stream)
		{
			using var sr1 = new StreamReader(stream);
			using var jsonr1 = new JsonTextReader(sr1);
			var js1 = new JsonSerializer();
			return js1.Deserialize<T>(jsonr1);
		}


		/// <summary>
		/// Возвращает объект типа T из файла json
		/// </summary>
		public static T GetObjectFromJsonFile<T>(
			string filename)
		{
			using var stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
			return GetObjectFromJson<T>(stream);
		}


		/// <summary>
		/// Записывает json объекта в поток
		/// </summary>
		public static void WriteObjectToStream(
			object obj,
			Stream stream)
		{
			using var sw1 = new StreamWriter(stream);
			using var jsonw1 = new JsonTextWriter(sw1);
			var js1 = new JsonSerializer();
			js1.Serialize(jsonw1, obj);
			jsonw1.Flush();
		}


		/// <summary>
		/// Сохраняет объект в файл json
		/// </summary>
		public static void SaveObjectToJsonFile(
			object obj,
			string filename)
		{
			using var stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
			WriteObjectToStream(obj, stream);
		}

	}

}
