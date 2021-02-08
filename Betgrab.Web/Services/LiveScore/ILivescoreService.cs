using System;

namespace Betgrab.Web.Services.LiveScore
{
	public interface ILivescoreService
	{
		event OnLivescoreOutputEventHandler OnOutput;
		int ParseDate(DateTime date);
		int ParseEvent(int eventId);
	}
}
