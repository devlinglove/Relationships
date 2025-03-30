using Dometrain.EFCore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Dometrain.EFCore.API.Data.EntityMapping
{
	public class LookupConfiguration : IEntityTypeConfiguration<Lookup>
	{
		public void Configure(EntityTypeBuilder<Lookup> builder)
		{
			// Table configuration
			builder.ToTable("LookupValues");

			// Primary key
			builder.HasKey(x => x.Id);

			// Properties configuration
			builder.Property(x => x.Name)
				  .IsRequired()
				  .HasMaxLength(100);

			builder.Property(x => x.Description)
				  .HasMaxLength(255);

			builder.Property(x => x.SortOrder)
				  .HasDefaultValue(0);

			builder.Property(x => x.IsActive)
				  .HasDefaultValue(true);


			// Seed data (must match the GUIDs from LookupType)
			var genderTypeId = Guid.Parse("a1b2c3d4-1234-5678-9012-abcdef123456");
			var countryTypeId = Guid.Parse("b2c3d4e5-2345-6789-0123-bcdef123456a");
			var regionTypeId = Guid.Parse("c3d4e5f6-3456-7890-1234-cdef123456ab");

			builder.HasData(
			// Gender values
				new Lookup
				{
					Id = Guid.NewGuid(),
					LookupTypeId = genderTypeId,
					Name = "Male",
					Description = "Male gender",
					SortOrder = 1,
					IsActive = true
				},
				new Lookup
				{
					Id = Guid.NewGuid(),
					LookupTypeId = genderTypeId,
					Name = "Female",
					Description = "Female gender",
					SortOrder = 2,
					IsActive = true
				},

				// Country values
				new Lookup
				{
					Id = Guid.NewGuid(),
					LookupTypeId = countryTypeId,
					Name = "United Kingdom",
					Description = "UK",
					SortOrder = 1,
					IsActive = true
				},

				// Region values
				new Lookup
				{
					Id = Guid.NewGuid(),
					LookupTypeId = regionTypeId,
					Name = "London",
					Description = "Greater London",
					SortOrder = 1,
					IsActive = true
				}
			);

		}
	}
}
