using Betgrab.Domain.Interfaces;

namespace Betgrab.Domain.Entities
{
	public class Stage : IEntity, ILivescore
	{
		public Stage()
		{
		}

		public int Id { get; set;  }
		public string LivescoreId { get; set;  }
		public string Name { get; set; }

		/// <summary>
		/// Соревнование, в рамках которого происходит встреча
		/// </summary>
		public League League { get; set; }
		public int? LeagueId { get; set; }
	}
}
