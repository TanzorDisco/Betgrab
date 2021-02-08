namespace Betgrab.Web.Services
{
	public interface IHttpHelperService
	{
		string Get(string url);
		string Post(string url, object data);
	}
}
