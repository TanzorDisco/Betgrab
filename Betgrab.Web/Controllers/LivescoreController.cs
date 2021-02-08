using Betgrab.Web.Hubs;
using Betgrab.Web.Services.Adapters.LiveScore;
using Betgrab.Web.Services.LiveScore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Betgrab.Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class LivescoreController : BetgrabController
	{
		private static object sync = new object();
		private readonly Livescore _livescore;
		private ILivescoreAdapter _liveScoreAdapter;
		private ILivescoreService _livescoreService;
		private IHubContext<BetgrabHub> _hubContext;

		public LivescoreController(
			ILivescoreAdapter liveScoreAdapter, 
			ILivescoreService livescoreService,
			IHubContext<BetgrabHub> hubContext,
			Livescore livescore) : base()
		{
			_livescore = livescore;

			_liveScoreAdapter = liveScoreAdapter;
			_hubContext = hubContext;

			_livescoreService = livescoreService;
			_livescoreService.OnOutput += onLivescoreOutput;
		}

		[HttpGet("current")]
		public IActionResult GetRunningTasks()
		{
			return Ok(_livescore.RunningTasks.Keys);
		}

		[HttpGet("parse/{date}")]
		public IActionResult ParseDate(string date)
		{
			if (!_livescore.IsRunning(date))
			{
				_livescore.AddTask(date, null);

				_hubContext.Clients.All.SendAsync("onNewOutput", new { id = date });

				_livescoreService.ParseDate(DateTime.Parse(date, new CultureInfo("en-US")));

				_livescore.RemoveTask(date);

				return Ok();
			}
			else
			{
				return Ok(new { alreadyRunning = true });
			}
		}

		private void onLivescoreOutput(object sender, string date, string message)
		{
			_hubContext.Clients.All.SendAsync("onWriteToLivescoreOutput", new { id = date, message });
		}

		[HttpGet("soccer")]
		public IActionResult SoccerResults(string date)
		{
			return Json(_liveScoreAdapter.GetResults(DateTime.Parse(date)));
		}

		[HttpGet("event")]
		public IActionResult EventData(string eventId)
		{
			return Json(_liveScoreAdapter.GetEventData(eventId));
		}

		//[HttpGet("premierleague")]
		//public IActionResult GetEnglandPremierLeague()
		//{
		//	return Json(_liveScoreAdapter.GetEnglandPremierLeague());
		//}

		//[HttpGet("laligasantander")]
		//public IActionResult GetSpainLaligaSantander()
		//{
		//	return Json(_liveScoreAdapter.GetSpainLaligaSantander());
		//}

	}
}
