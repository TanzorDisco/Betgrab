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
			_livescoreService.OnOutput += onOutput;
			_livescoreService.OnProgress += onProgress;
		}

		[HttpGet("current")]
		public async Task<IActionResult> GetRunningTasks()
		{
			return await Task.Run(() => Ok(_livescore.RunningTasks.Keys));
		}

		[HttpGet("parse/{date}")]
		public async Task<IActionResult> ParseDate(string date)
		{
			_livescoreService.EventOutputOnly = true;

			if (!_livescore.IsRunning(date))
			{
				_livescore.AddTask(date, null);

				var dateTime = DateTime.Parse(date, new CultureInfo("en-US"));
				
				await _hubContext.Clients.All.SendAsync("onNewOutput", new { id = date });

				await _livescoreService.ParseDateAsync(dateTime);

				_livescore.RemoveTask(date);

				return Ok();
			}
			else
			{
				return Ok(new { alreadyRunning = true });
			}
		}

		private void onOutput(object sender, string date, string message)
		{
			_hubContext.Clients.All.SendAsync("onWriteToLivescoreOutput", new { id = date, message });
		}

		private void onProgress(object sender, string date, int progress) 
		{
			_hubContext.Clients.All.SendAsync("onLivescoreEventProgress", new { id = date, progress });
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

	}
}
