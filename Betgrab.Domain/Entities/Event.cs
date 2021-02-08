using Betgrab.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Betgrab.Domain.Entities
{
	/// <summary>
	/// Спортивное событие, матч
	/// </summary>
	public class Event : IEntity, ILivescore
	{
		public Event()
		{
			Facts = new List<Fact>();
		}

		public int Id { get; set; }

		/// <summary>
		/// Дата начала события
		/// </summary>
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// Дата окончания события
		/// </summary>
		public DateTime? FinishDate { get; set; }

		/// <summary>
		/// Количество голов первой команды в основное время
		/// </summary>
		public byte? Tr1 { get; set; }

		/// <summary>
		/// Количество голов второй команды в основное время
		/// </summary>
		public byte? Tr2 { get; set; }

		/// <summary>
		/// Количество голов первой команды в первом тайме
		/// </summary>
		public byte? Trh1 { get; set; }

		/// <summary>
		/// Количество голов второй команды в первом тайме
		/// </summary>
		public byte? Trh2 { get; set; }

		/// <summary>
		/// Количество голов первой команды в матче в целом 
		/// </summary>
		public byte? Tr1OR { get; set; }

		/// <summary>
		/// Количество голов второй команды в матче в целом 
		/// </summary>
		public byte? Tr2OR { get; set; }


		/// <summary>
		/// Идентификатор события в livescore.com
		/// </summary>
		public string LivescoreId { get; set; }

		/// <summary>
		/// Команда #1
		/// </summary>
		public Club Club1 { get; set; }
		public int? Club1Id { get; set; }

		/// <summary>
		/// Команда #2
		/// </summary>
		public Club Club2 { get; set; }
		public int? Club2Id { get; set; }

		/// <summary>
		/// Было ли событие отменено
		/// </summary>
		public bool IsCancelled { get; set; }

		/// <summary>
		/// Турнир
		/// </summary>
		public Stage Stage { get; set; }
		public int? StageId { get; set; }

		/// <summary>
		/// Голы
		/// </summary>
		public List<Fact> Facts { get; set; }

		/// <summary>
		/// Что произошло во время матча
		/// </summary>
		public List<EventStats> Stats { get; set; }
	}
}
