using QuizGame.Enums;
using QuizGame.Models;

namespace QuizGame.Data.Interfaces;

public interface IQuestionRepo
{
    bool SaveChanges();

    Question GetQuestionById(int id);

    Question GetRandomQuestionByType(QuestionType type);
}