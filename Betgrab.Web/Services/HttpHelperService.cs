using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace Betgrab.Web.Services
{
	public class HttpHelperService : IHttpHelperService
	{
		public HttpHelperService()
		{
		}

		public string Get(string url)
		{
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

			request.Method = "GET";

			return ReadFromStream(request.GetResponse().GetResponseStream());
		}

		public string Post(string url, object data)
		{
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

			request.Method = "POST";

			WriteToStream(request.GetRequestStream(), data);

			return ReadFromStream(request.GetResponse().GetResponseStream());
		}

		private void WriteToStream(Stream stream, object body)
		{
			using StreamWriter sw = new StreamWriter(stream);

			sw.Write(JsonConvert.SerializeObject(body));
		}

		private string ReadFromStream(Stream stream)
		{
			using StreamReader sr = new StreamReader(stream);

			return sr.ReadToEnd();
		}
	}
}
