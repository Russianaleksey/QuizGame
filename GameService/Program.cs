using QuizGame.Data;
using Microsoft.EntityFrameworkCore;
using QuizGame.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddScoped<IGameRepo, GameRepo>();
builder.Services.AddScoped<IPlayerRepo, PlayerRepo>();
builder.Services.AddScoped<IBoardRepo, BoardRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DbPath")));

var app = builder.Build();


//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();