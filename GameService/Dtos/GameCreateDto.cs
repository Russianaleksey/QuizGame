using System.ComponentModel.DataAnnotations;

namespace QuizGame.Dtos;

public class GameCreateDto
{
    [Required] public string Name { get; set; }
}