using Betgrab.Web.Adapters.Livescore.Event;
using Betgrab.Web.Adapters.Livescore.Results;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Betgrab.Web.Services.Adapters.LiveScore
{
	public class LivescoreAdapter : ILivescoreAdapter
	{
		private static string BASE_URL = "https://prod-public-api.livescore.com/v1/api/react/stage/soccer/";
		private static string SOCCER_RESULTS_URL = "https://prod-public-api.livescore.com/v1/api/react/date/soccer/{{yyyyMMdd}}/3.00";
		private static string EVENT_URL = "https://prod-public-api.livescore.com/v1/api/react/match-x/soccer/{{eventId}}/3";

		private string ENGLAND_PREMIER_LEAGUE = $"{BASE_URL}england/premier-league/3.00";
		private string SPAIN_LALIGA_SANTANDER = $"{BASE_URL}spain/laliga-santander/3.00";
		private readonly IHttpHelperService _http;

		public LivescoreAdapter(IHttpHelperService http)
		{
			_http = http;
		}

		public LivescoreAdapter()
		{
		}

		public LiveScoreResponseDto GetResults(DateTime date)
		{
			string url = SoccerResultsUrl(date);

			string json = _http.Get(url);

			return JsonConvert.DeserializeObject<LiveScoreResponseDto>(json);
		}

		public LivescoreEventDto GetEventData(string eventId) 
		{
			string url = EventUrl(eventId);

			string json = _http.Get(url);

			return JsonConvert.DeserializeObject<LivescoreEventDto>(json);
		}

		public object GetEnglandPremierLeague()
		{
			var json = _http.Get(ENGLAND_PREMIER_LEAGUE);

			var response = JsonConvert.DeserializeObject<LiveScoreResponseDto>(json);

			if (!response.Stages.Any())
				return null;

			return response.Stages.First()
				.Events
				.Select(e => new
				{
					Display = $"{e.T1.First().Nm} {e.Tr1} : {e.Tr2} {e.T2.First().Nm}",
					EventId = e.Eid,
					Club1 = e.T1.First().Nm,
					Club2 = e.T2.First().Nm,
					Tr1 = e.Tr1,
					Tr2 = e.Tr2
				});
		}

		public object GetSpainLaligaSantander()
		{
			var json = _http.Get(SPAIN_LALIGA_SANTANDER);

			return  JsonConvert.DeserializeObject<LiveScoreResponseDto>(json);
		}

		public string SoccerResultsUrl(DateTime date)
		{
			return SOCCER_RESULTS_URL.Replace("{{yyyyMMdd}}", date.ToString("yyyyMMdd"));
		}

		public string EventUrl(string eventId)
		{
			return EVENT_URL.Replace("{{eventId}}", eventId);
		}
	}
}
