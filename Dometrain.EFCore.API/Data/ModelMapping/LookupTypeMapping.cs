using Dometrain.EFCore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;
using System.Reflection.Metadata;


namespace Dometrain.EFCore.API.Data.EntityMapping
{
	public class LookupTypeMapping : IEntityTypeConfiguration<LookupType>
	{
		public void Configure(EntityTypeBuilder<LookupType> builder)
		{
			builder.ToTable("LookupTypes").HasKey(x => x.Id);

			builder.Property(x => x.TypeName)
			  .IsRequired()
			  .HasMaxLength(100);

			builder.Property(x => x.Description)
				  .HasMaxLength(255);

			builder.Property(x => x.IsActive)
				  .HasDefaultValue(true);

			builder
			.HasMany<Lookup>()
			.WithOne(e => e.LookupType)
			.HasForeignKey(e => e.LookupTypeId)
			.OnDelete(DeleteBehavior.Cascade);

			var genderTypeId = Guid.Parse("a1b2c3d4-1234-5678-9012-abcdef123456");
			var countryTypeId = Guid.Parse("b2c3d4e5-2345-6789-0123-bcdef123456a");
			var regionTypeId = Guid.Parse("c3d4e5f6-3456-7890-1234-cdef123456ab");

			builder.HasData(
				new LookupType
				{
					Id = genderTypeId,
					TypeName = "Gender",
					Description = "Gender identity options",
					IsActive = true
				},
				new LookupType
				{
					Id = countryTypeId,
					TypeName = "Country",
					Description = "List of countries",
					IsActive = true
				},
				new LookupType
				{
					Id = regionTypeId,
					TypeName = "Provinces",
					Description = "English regions",
					IsActive = true
				}
			);

		}

	}
}
