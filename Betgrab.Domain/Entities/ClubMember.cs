using System;

namespace Betgrab.Domain.Entities
{
	/// <summary>
	/// Участие в кл
	/// </summary>
	public class ClubMember : IEntity
	{
		public int Id { get; set; }

		/// <summary>
		/// Клуб
		/// </summary>
		public Club Club { get; set; }
		public int ClubId { get; set; }

		/// <summary>
		/// Игрок (или тренер)
		/// </summary>
		public Player Player { get; set; }
		public int PlayerId { get; set; }

		/// <summary>
		/// Дата перехода в клуб
		/// </summary>
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// Дата ухода из клуба
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// Аренда игрока
		/// </summary>
		public bool IsLeasing { get; set; }
	}
}
