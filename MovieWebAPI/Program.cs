using MovieWebAPI.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//when we add the service, we are telling the application to use the MovieDal class when it needs to use the IMovieDal interface
//builder.Services.AddSingleton<IMovieDal, MovieDal>();
builder.Services.AddScoped<MovieWebAPI.Database.MovieDal>();
builder.Services.AddScoped<MovieWebAPI.Database.ActorDal>();
builder.Services.AddScoped<MovieWebAPI.Database.DirectorDal>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
