using System.ComponentModel.DataAnnotations;

namespace QuizGame.Models;

public class Board
{
    [Key]
    [Required]
    public int BoardId { get; set; }

    public string FriendlyName { get; set; } = "Giraffe";

    public int BoardSize { get; set; } = 18;
    public string Spaces { get; set; } = "0200400001000300";
    public int? GameId { get; set; }
    public Game? Game { get; set; }

    

}