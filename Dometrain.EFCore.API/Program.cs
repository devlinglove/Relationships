using Dometrain.EFCore.API.Data;
using Dometrain.EFCore.API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add a DbContext here
//builder.Services.AddDbContext<MoviesContext>();
builder.Services.AddDbContext<UserContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
});

var app = builder.Build();
// DIRTY HACK, we WILL come back to fix this
var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<UserContext>();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

if (!context.LookupTypes.Any())
{
	var genderType = new LookupType
	{
		TypeName = "Gender",
		Description = "Gender identity options"
	};


	context.LookupTypes.AddRange(genderType);
	context.SaveChanges();

	var lookupValues = new List<Lookup>
	{
        // Gender options
        new Lookup
		{
			LookupTypeId = genderType.Id,
			Name = "Male",
			Description = "Male gender",
			SortOrder = 1
		},
		new Lookup
		{
			LookupTypeId = genderType.Id,
			Name = "Female",
			Description = "Female gender",
			SortOrder = 2
		},
		new Lookup
		{
			LookupTypeId = genderType.Id,
			Name = "Non-binary",
			Description = "Non-binary gender identity",
			SortOrder = 3
		},
		new Lookup
		{
			LookupTypeId = genderType.Id,
			Name = "Prefer not to say",
			Description = "Option to not disclose gender",
			SortOrder = 4
		}
	};

	context.Lookups.AddRange(lookupValues);
	context.SaveChanges();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();