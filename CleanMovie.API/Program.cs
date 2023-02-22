using CleanMovie.Application;
using CleanMovie.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Register Configuration

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

//Add Database dependency
//builder.Services.AddDbContext<MovieDBContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
//    b => b.MigrationsAssembly("CleanMovie.API")));

//Database dependency moved to infrastructure layer.
//Implement Infrastructure DependencyInjection Container.
builder.Services.ImplementPersistence(builder.Configuration);
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
