using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Betgrab.Web.Hubs
{
	public class BetgrabHub : Hub
	{
		public BetgrabHub()
		{
		}

		public async Task ParseDate(string date)
		{
			// await Clients.All.SendAsync("OnWriteToLivescoreOutput", message);
		}
		
	}
}
