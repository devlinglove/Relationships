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
//var context = scope.ServiceProvider.GetRequiredService<UserContext>();
//context.Database.EnsureDeleted();
//context.Database.EnsureCreated();
try
{
	var context = scope.ServiceProvider.GetRequiredService<UserContext>();
	context.Database.EnsureDeleted();
	context.Database.EnsureCreated();
	SeedDB.Seed(context);
}
catch (Exception ex)
{
	var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
	logger.LogError(ex, "An error occurred while seeding the database.");
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