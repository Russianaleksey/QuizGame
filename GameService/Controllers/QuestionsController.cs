using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizGame.Data.Interfaces;
using QuizGame.Dtos;
using QuizGame.Enums;
using QuizGame.Requests;

namespace QuizGame.Controllers;


[Route("api/[controller]")]
[ApiController]
public class QuestionsController : ControllerBase
{
    private readonly ILogger<QuestionsController> _logger;
    private readonly IMapper _mapper;
    private readonly IQuestionRepo _questionRepo;
    
    public QuestionsController(ILogger<QuestionsController> logger, IMapper mapper, IQuestionRepo questionRepo)
    {
        _mapper = mapper;
        _logger = logger;
        _questionRepo = questionRepo;
    }
    

    [HttpGet]
    [CheckQueryString("questionType", true)]
    public ActionResult<QuestionReadDto> GetQuestionByType([FromQuery] QuestionType questionType)
    {
        var question = _questionRepo.GetRandomQuestionByType(questionType);
        return Ok(_mapper.Map<QuestionReadDto>(question));
    }
}