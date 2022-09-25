using Microsoft.EntityFrameworkCore;
using QuizGame.Enums;
using QuizGame.Models;

namespace QuizGame.Data;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>().HasOne(g => g.Board).WithOne(b => b.Game).HasForeignKey<Board>(b => b.GameId);
        modelBuilder.Entity<Game>().HasMany(g => g.Players).WithOne(p => p.Game).HasForeignKey(p => p.GameId);
        
        modelBuilder.Entity<Game>().HasData(
            new Game { GameId = 1, Name = "AlexGame", State = State.NotStarted }, 
            new Game { GameId = 2, Name = "BigGamersOnly", State = State.NotStarted },
            new Game { GameId = 3, Name = "SmallGamersOnly", State = State.NotStarted }
        );

        modelBuilder.Entity<Board>().HasData(
            new Board { BoardId = 1, GameId = 1, FriendlyName = "GiraffeBoard"},
            new Board { BoardId = 2, GameId = 2, FriendlyName = "CheetahBoard"}
        );

        modelBuilder.Entity<Player>().HasData(
            new Player {PlayerId = 1, Name = "Alex", GameId = 1},
            new Player {PlayerId = 2, Name = "Brian", GameId = 1},
            new Player {PlayerId = 3, Name = "Jahlaud", GameId = 1},
            new Player {PlayerId = 4, Name = "Adrian", GameId = 1},
            new Player {PlayerId = 5, Name = "Felix", GameId = 1}
        );
    }
    
}