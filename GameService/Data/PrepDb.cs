using Microsoft.EntityFrameworkCore;
using QuizGame.Models;

namespace QuizGame.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app, bool isProd)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
        }
    }

    public static void SeedData(AppDbContext context, bool isProd)
    {

        context.Database.Migrate();

        if (!context.Games.Any())
        {
            Console.WriteLine("--> Seeding game data...");
            
            context.Games.AddRange(
                new Game {Name = "Game night with the bois"},
                new Game {Name = "Girls night game"}
                );
            
            context.Players.AddRange(
                new Player {Name = "Alex", GameId = 1},
                new Player {Name = "Brian", GameId = 1},
                new Player {Name = "Jah", GameId = 1},
                new Player {Name = "Aaron", GameId = 1},
                new Player {Name = "Carlex", GameId = 2},
                new Player {Name = "Rolston", GameId = 2}
                );

            context.SaveChanges();

        }
        else
        {
            Console.WriteLine("--> We already have game data...");
        }
    }
}