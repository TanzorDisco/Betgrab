using Betgrab.Web.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Betgrab.Web.Extensions
{
	public static class AnalogExtensions
	{
		public static IEnumerable<Analog> DistinctByIndex(this IEnumerable<Analog> items)
		{
			return items.GroupBy(a => new { a.Type, a.Service, a.ServiceId })
				.Select(g => new Analog
				{
					Type = g.Key.Type,
					Service = g.Key.Service,
					ServiceId = g.Key.ServiceId,
					Json = g.OrderBy(a => Guid.NewGuid()).First().Json
				});
		}
	}
}
