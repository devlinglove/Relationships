namespace Dometrain.EFCore.API.Models
{
	public class LookupType
	{
		public Guid Id { get; set; }
		public string TypeName { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public bool IsActive { get; set; } = true;
		public ICollection<Lookup> Lookups { get; set; }
	}

}
