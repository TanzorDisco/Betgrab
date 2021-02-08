using Betgrab.Domain.Interfaces;
using System.Collections.Generic;

namespace Betgrab.Domain.Entities
{
	/// <summary>
	/// Атлет/тренер (человек)
	/// </summary>
	public class Player : IEntity, ILivescore
	{
		public Player()
		{
			Nationality = new List<Nation>();
			ClubParticipation = new List<ClubMember>();
		}

		public int Id { get; set; }

		/// <summary>
		/// Идентификатор игрока в http://livescore.com
		/// </summary>
		public string LivescoreId { get; set; }

		/// <summary>
		/// Имя
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Позиция
		/// </summary>
		public string PositionName { get; set; }

		/// <summary>
		/// Номер игрока на поле
		/// </summary>
		public int? PlayerNumber { get; set; }

		/// <summary>
		/// Фамилия Имя
		/// </summary>
		public string FullName => $"{LastName}-{FirstName}";

		/// <summary>
		/// Гражданство
		/// </summary>
		public List<Nation> Nationality { get; set; }

		/// <summary>
		/// Клубная карьера игрока
		/// </summary>
		public List<ClubMember> ClubParticipation { get; set; }
	}
}
