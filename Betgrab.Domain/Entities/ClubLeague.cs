using System;

namespace Betgrab.Domain.Entities
{
	/// <summary>
	/// Участие клуба в турнире
	/// </summary>
	public class ClubLeague : IEntity
	{
		public int Id { get; set; }

		/// <summary>
		/// Турнир
		/// </summary>
		public League League { get; set; }
		public int LeagueId { get; set; }

		/// <summary>
		/// Клуб
		/// </summary>
		public Club Club { get; set; }
		public int ClubId { get; set; }

		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
	}
}
