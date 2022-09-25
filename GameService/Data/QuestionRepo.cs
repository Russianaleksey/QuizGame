using QuizGame.Data.Interfaces;
using QuizGame.Enums;
using QuizGame.Models;
using QuizGame.Utilities;

namespace QuizGame.Data;

public class QuestionRepo : IQuestionRepo
{
    private readonly AppDbContext _context;
    private readonly IRandomNumberGenerator _randomNumberGenerator;
    
    public QuestionRepo(AppDbContext context, IRandomNumberGenerator randomNumberGenerator)
    {
        _context = context;
        _randomNumberGenerator = randomNumberGenerator;
    }
    
    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }

    public Question GetQuestionById(int id)
    {
        return _context.Questions.FirstOrDefault(q => q.QuestionId == id);
    }

    public Question GetRandomQuestionByType(QuestionType type)
    {
        var questionsOfSameType = _context.Questions.Where(q => q.Type == type).ToList();

        var randomElementIndex = _randomNumberGenerator.GetRandomInteger(0, questionsOfSameType.Count);

        var randomQuestion = questionsOfSameType[randomElementIndex];

        return randomQuestion;
    }
}