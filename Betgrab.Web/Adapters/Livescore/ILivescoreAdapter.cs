using Betgrab.Web.Adapters.Livescore.Results;
using Betgrab.Web.Adapters.Livescore.Event;
using System;

namespace Betgrab.Web.Services.Adapters.LiveScore
{
	public interface ILivescoreAdapter
	{
		LiveScoreResponseDto GetResults(DateTime date);
		LivescoreEventDto GetEventData(string eventId);
	}
}
