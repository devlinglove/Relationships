using Dometrain.EFCore.API.Data.EntityMapping;
using Dometrain.EFCore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Dometrain.EFCore.API.Data;

public class UserContext : DbContext
{
	public UserContext(DbContextOptions options) : base(options)
	{ }
	public DbSet<LookupType> LookupTypes => Set<LookupType>();
    public DbSet<Lookup> Lookups => Set<Lookup>(); 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
        base.OnConfiguring(optionsBuilder);
    }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		//modelBuilder.ApplyConfiguration(new GenreMapping());
		//modelBuilder.ApplyConfiguration(new MovieMapping());
		
	}

}