using System;
using System.Threading.Tasks;

namespace Betgrab.Web.Services.LiveScore
{
	public interface ILivescoreService
	{
		event OnLivescoreOutputEventHandler OnOutput;
		event OnLivescoreProgressEventHandler OnProgress;
		int ParseDate(DateTime date);
		Task<int> ParseDateAsync(DateTime date);
		bool EventOutputOnly { get; set; }
	}
}
