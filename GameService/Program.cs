using QuizGame.Data;

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
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();