using Betgrab.Domain.Interfaces;
using System.Collections.Generic;

namespace Betgrab.Domain.Entities
{
	/// <summary>
	/// Футбольный клуб
	/// </summary>
	public class Club : IEntity, ILivescore
	{
		public int Id { get; set; }

		/// <summary>
		/// Наименование
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Идентификатор клуба в livescore.com
		/// </summary>
		public string LivescoreId { get; set; }

		/// <summary>
		/// Страна
		/// </summary>
		public Nation Nation { get; set; }
		public int? NationId { get; set; }

		/// <summary>
		/// Члены клуба
		/// </summary>
		public List<ClubMember> Members { get; set; }

		/// <summary>
		/// Участие в турнирах
		/// </summary>
		public List<ClubLeague> Leagues { get; set; }
	}
}
