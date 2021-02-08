using Betgrab.Domain.Interfaces;

namespace Betgrab.Domain.Entities
{
	public class Fact : IEntity, ILivescore
	{
		public int Id { get; set; }
		public string LivescoreId { get; set; }
		public MatchFacts Type { get; set; }
		public byte Min { get; set; }
		public byte? MinEx { get; set; }

		public Event Event { get; set; }
		public int? EventId { get; set; }

		public Player Player { get; set; }
		public int? PlayerId { get; set; }
	}


	public enum MatchFacts
	{
		Goal = 36,

		GoalPen = 37,

		MissedPen = 38,

		Yellow = 43,

		TwoYellows = 44,

		Red = 45,

		Assist = 63,
	}
}
