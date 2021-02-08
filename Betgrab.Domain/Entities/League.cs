using Betgrab.Domain.Interfaces;
using System.Collections.Generic;

namespace Betgrab.Domain.Entities
{
	/// <summary>
	/// Турнир
	/// </summary>
	public class League : IEntity, ILivescore
	{
		public int Id { get; set; }

		public League()
		{
			Clubs = new List<ClubLeague>();
		}
		
		/// <summary>
		/// Наименование турнира
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Страна
		/// </summary>
		public Nation Nation { get; set; }
		public int? NationId { get; set; }

		/// <summary>
		/// Год старта турнира
		/// </summary>
		public int Year { get; set; }

		/// <summary>
		/// Международный
		/// </summary>
		public bool IsInternational { get; set; }

		/// <summary>
		/// Клубы
		/// </summary>
		public List<ClubLeague> Clubs { get; set; }

		/// <summary>
		/// Турниры
		/// </summary>
		public List<Stage> Competitions { get; set; }

		/// <summary>
		/// Идентификатор лиги в livescore.com
		/// </summary>
		public string LivescoreId { get; set; }
	}
}
