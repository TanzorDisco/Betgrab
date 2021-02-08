using Betgrab.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Betgrab.Web.Extensions
{
	public static class DbContextExtensions
	{
		public static bool TryFind<T>(this DbSet<T> dbSet, int id, out T e)
			where T : class
		{
			e = dbSet.Find(id);

			return e != null;
		}

		public static bool TryFindLivescore<T>(this DbSet<T> dbSet, string id, out T e)
			where T : class, ILivescore
		{
			e = dbSet.FirstOrDefault(x => x.LivescoreId == id);

			return e != null;
		}
	}
}
