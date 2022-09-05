using System.ComponentModel.DataAnnotations;

namespace QuizGame.Models;

public class Player
{
    [Required]
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    public int GameId { get; set; }
    
    public Game Game { get; set; } = null;
}