using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Betgrab.Domain.Entities
{
	public interface IEntity
	{
		int Id { get; set; }
	}
}
