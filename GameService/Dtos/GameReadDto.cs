using QuizGame.Enums;

namespace QuizGame.Dtos;

public class GameReadDto
{
    public int GameId { get; set; }
    public string Name { get; set; }
    public State State { get; set; }
}