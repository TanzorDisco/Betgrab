using System;

namespace Betgrab.Web.Extensions
{
	public static class CommonExtensions
	{
		public static DateTime? ToDateTime(this long? value)
		{
			if (value == null || value == 0)
				return null;

			return DateTime.ParseExact(value.ToString(), "yyyyMMddHHmmss", null);
		}
	}
}
