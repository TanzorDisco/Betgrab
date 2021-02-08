using Betgrab.Domain;
using Betgrab.Domain.Entities;
using Betgrab.Domain.Interfaces;
using Betgrab.Web.Adapters;
using System.Linq;

namespace Betgrab.Web.Services
{
	public class AnalogResolvingService : BaseService, IAnalogResolvingService
	{
		public AnalogResolvingService(BetgrabContext context) : base(context)
		{
		}

		public T ResolveLivescoreAnalog<T>(Analog analog, bool create = true)
			where T : class, ILivescore, new()
		{
			if (analog == null)
				return null;

			T e = Ctx.Set<T>().FirstOrDefault(l => l.LivescoreId == analog.ServiceId);

			if (e == null)
			{
				e = new T() { LivescoreId = analog.ServiceId };

				Ctx.Set<T>().Add(e);

				Ctx.SaveChanges();
			}

			return e;
		}
	}
}
