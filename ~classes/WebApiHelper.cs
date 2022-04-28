using Newtonsoft.Json;
using System.Net;

namespace Ans.Net6.Common
{

	public class WebApiHelper<TResponse>
	{

		public string BaseUrl { get; set; }
		public ParamsBuilder Params { get; set; }


		public WebApiHelper(
			string baseUrl)
		{
			this.BaseUrl = baseUrl;
			this.Params = new ParamsBuilder();
		}


		public string SendQueryToString(
			string queryString)
		{
			using var client = new HttpClient();
			using var response = client.GetAsync($"{BaseUrl}{queryString}").Result;
			using var content = response.Content;
			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
					return content.ReadAsStringAsync().Result;
				default:
					break;
			}
			return null;
		}


		public TResponse SendQuery(
			string queryString)
		{
			string json = SendQueryToString(queryString);
			if (string.IsNullOrEmpty(json) || json == "null")
				return default;
			return JsonConvert.DeserializeObject<TResponse>(json);
		}


		public TResponse SendQuery()
		{
			return SendQuery(Params.ToString());
		}

	}

}
