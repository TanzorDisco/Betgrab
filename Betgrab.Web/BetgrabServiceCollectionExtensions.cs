using Betgrab.Web.Services;
using Betgrab.Web.Services.Adapters.LiveScore;
using Betgrab.Web.Services.LiveScore;
using Microsoft.Extensions.DependencyInjection;

namespace Betgrab.Web
{
	public static class BetgrabServiceCollectionExtensions
	{
		public static IServiceCollection AddBetgrab(this IServiceCollection services)
		{
			services.AddTransient<IHttpHelperService, HttpHelperService>();
			services.AddTransient<ILivescoreAdapter, LivescoreAdapter>();

			services.AddTransient<IAnalogResolvingService, AnalogResolvingService>();
			services.AddTransient<ILivescoreService, LivescoreService>();

			services.AddSingleton(typeof(Livescore));

			return services;
		}
	}
}
