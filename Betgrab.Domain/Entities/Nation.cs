using Betgrab.Domain.Interfaces;
using System.Collections.Generic;

namespace Betgrab.Domain.Entities
{
	/// <summary>
	/// Страна
	/// </summary>
	public class Nation : IEntity, ILivescore
	{
		public Nation()
		{
			Citizens = new List<Player>();
			Clubs = new List<Club>();
		}

		public int Id { get; set; }

		/// <summary>
		/// Наименование
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Граждане страны
		/// </summary>
		public List<Player> Citizens { get; set; }

		/// <summary>
		/// Клубы
		/// </summary>
		public List<Club> Clubs { get; set; }

		/// <summary>
		/// Идентификатор клуба в livescore.com
		/// </summary>
		public string LivescoreId { get; set; }
	}
}
