using Betgrab.Domain.Interfaces;
using Betgrab.Web.Adapters;

namespace Betgrab.Web.Services
{
	public interface IAnalogResolvingService
	{
		T ResolveLivescoreAnalog<T>(Analog analog, bool create = true) where T : class, ILivescore, new();
	}
}
