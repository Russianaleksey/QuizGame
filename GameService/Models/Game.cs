using System.ComponentModel.DataAnnotations;
using QuizGame.Enums;

namespace QuizGame.Models;

public class Game
{
    [Key]
    [Required]
    public int GameId { get; set; }

    [Required]
    public string Name { get; set; }

    public State State { get; set; } = State.NotStarted;
    
    public ICollection<Player> Players { get; set; } = new List<Player>();
}