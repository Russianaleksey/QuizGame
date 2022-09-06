using System.ComponentModel.DataAnnotations;
namespace QuizGame.Models;

public class Game
{
    [Key]
    [Required]
    public int GameId { get; set; }

    [Required]
    public string Name { get; set; }

    public ICollection<Player> Players { get; set; } = new List<Player>();
}