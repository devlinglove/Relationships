using Dometrain.EFCore.API.Models;

namespace Dometrain.EFCore.API.Data
{
	public static class SeedDB
	{
		public static void Seed(UserContext context)
		{
			if (!context.LookupTypes.Any())
			{
				// Pre-generate all GUIDs
				var genderTypeId = Guid.NewGuid();
				var countryTypeId = Guid.NewGuid();
				var englandProvinceTypeId = Guid.NewGuid();

				// Insert lookup types
				context.LookupTypes.AddRange(
					new LookupType { Id = genderTypeId, TypeName = "Gender", Description = "Gender identity options" },
					new LookupType { Id = countryTypeId, TypeName = "Country", Description = "List of countries" },
					new LookupType { Id = englandProvinceTypeId, TypeName = "Provinces", Description = "Regions/Provinces of England" }
				);

				// Insert lookup values
				context.Lookups.AddRange(
					// Gender options
					new Lookup { Id = Guid.NewGuid(), LookupTypeId = genderTypeId, Name = "Male", SortOrder = 1 },
					new Lookup { Id = Guid.NewGuid(), LookupTypeId = genderTypeId, Name = "Female", SortOrder = 2 }
				// ... add all other values similarly
				);

				context.SaveChanges();
			}
		}
	}
}
