namespace Dometrain.EFCore.API.Models
{
	public class Lookup
	{
		public Guid Id { get; set; }
		public Guid LookupTypeId { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int SortOrder { get; set; } = 0;
		public bool IsActive { get; set; } = true;

		public LookupType LookupType { get; set; }
	}






}
