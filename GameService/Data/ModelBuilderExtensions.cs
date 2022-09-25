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

        modelBuilder.Entity<Question>().HasData(
            new Question
            {
                QuestionId = 1, 
                Type = QuestionType.ComputerScience, 
                ProblemStatement = "What\'s the name of the machine used by the allies in WW2 to crack Germany's codes?",
                Answer = "Enigma"
            },
            new Question
            {
                QuestionId = 2, 
                Type = QuestionType.ComputerScience, 
                ProblemStatement = "Who is the father of computer science?",
                Answer = "Alan Turing"
            },
            new Question
            {
                QuestionId = 3, 
                Type = QuestionType.ComputerScience, 
                ProblemStatement = "What was the first computer system that used color display?",
                Answer = "Apple 1"
            },
            new Question
            {
                QuestionId = 4, 
                Type = QuestionType.ComputerScience, 
                ProblemStatement = "What was the name of the first computer programmer?",
                Answer = "Ada Lovelace"
            },
            new Question
            {
                QuestionId = 5, 
                Type = QuestionType.ComputerScience, 
                ProblemStatement = "Which popular company designed the first CPU?",
                Answer = "Intel"
            },
            new Question
            {
                QuestionId = 6, 
                Type = QuestionType.ComputerScience, 
                ProblemStatement = "Which is the single most popular computer system ever sold?",
                Answer = "Commodore 64"
            }
        );
    }
    
}