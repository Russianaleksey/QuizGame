using QuizGame.Enums;

namespace QuizGame.Dtos;

public class QuestionReadDto
{
    public int QuestionId { get; set; }
    public string ProblemStatement { get; set; }
    public QuestionType Type { get; set; }
}