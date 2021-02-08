namespace Betgrab.Web.Adapters
{
	public class Analog
	{
		public override int GetHashCode()
		{
			return Type?.GetHashCode() + Service?.GetHashCode() + ServiceId?.GetHashCode() ?? 0;
		}

		public int Id { get; set; }
		public string Type { get; set; }
		public string ServiceId { get; set; }
		public string Service { get; set; }
		public dynamic Json { get; set; }
	}
}
