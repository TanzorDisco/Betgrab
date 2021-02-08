using Betgrab.Domain;

namespace Betgrab.Web.Services
{
	public class BaseService
	{
		protected BetgrabContext Ctx { get; set; }

		public BaseService(BetgrabContext context)
		{
			Ctx = context;
		}
	}
}
