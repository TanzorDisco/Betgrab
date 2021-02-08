namespace Betgrab.Domain.Entities
{
	/// <summary>
	/// Статистика матча
	/// </summary>
	public class EventStats : IEntity
	{
		public int Id { get; set; }

		/// <summary>
		/// Матч, к которому относятся данные статистические сведения
		/// </summary>
		public Event Event { get; set; }
		public int? EventId { get; set; }

		/// <summary>
		/// Клуб, к которому относятся данные статистические сведения
		/// </summary>
		public Club Club { get; set; }
		public int? ClubId { get; set; }


		/// <summary>
		/// Количество ударов в створ ворот
		/// </summary>
		public int ShotsOnTarget { get; set; }

		/// <summary>
		/// Количество ударов по воротам
		/// </summary>
		public int ShotsOffTarget { get; set; }

		/// <summary>
		/// Количество заблокированных ударов
		/// </summary>
		public int ShotsBlocked { get; set; }

		/// <summary>
		/// Процент владения мячом
		/// </summary>
		public int Possession { get; set; }

		/// <summary>
		/// Количество угловых
		/// </summary>
		public int CornerKicks { get; set; }

		/// <summary>
		/// Количество офсайдов
		/// </summary>
		public int Offsides { get; set; }

		/// <summary>
		/// Количество фолов
		/// </summary>
		public int Fouls { get; set; }

		/// <summary>
		/// Количество вбрасываний мяча из-за боковой 
		/// </summary>
		public int ThrowIns { get; set; }

		/// <summary>
		/// Количество желтых карточек
		/// </summary>
		public int YellowCards { get; set; }

		/// <summary>
		/// Количество удалений из-за двух желтых карточек
		/// </summary>
		public int YellowRedCards { get; set; }

		/// <summary>
		/// Количество прямых красных карточек
		/// </summary>
		public int RedCards { get; set; }

		/// <summary>
		/// Количество кроссов
		/// </summary>
		public int Crosses { get; set; }

		/// <summary>
		/// Количество контр-атак
		/// </summary>
		public int CounterAttacks { get; set; }

		/// <summary>
		/// Количество сейвов вратаря
		/// </summary>
		public int GoalkeeperSaves { get; set; }

		/// <summary>
		/// Количество ударов от ворот
		/// </summary>
		public int GoalKicks { get; set; }

		/// <summary>
		/// Количество травм (судя по всему)
		/// </summary>
		public int Treatments { get; set; }
	}
}
