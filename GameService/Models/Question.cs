using System.ComponentModel.DataAnnotations;
using QuizGame.Enums;

namespace QuizGame.Models;

public class Question
{
    [Required]
    [Key]
    public int QuestionId { get; set; }
    
    [Required]
    public string ProblemStatement { get; set; }
    
    [Required]
    public string Answer { get; set; }

    [Required] 
    public QuestionType Type { get; set; }
}