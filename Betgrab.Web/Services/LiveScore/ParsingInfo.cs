using System;

namespace Betgrab.Web.Services.LiveScore
{
	public class ParsingInfo
	{
		public bool IsRunning { get; set; }
		public DateTime Date { get; set; }
		public int EventId { get; set; }
		public int EventsProcessed { get; set; }
	}
}
