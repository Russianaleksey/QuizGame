using AutoMapper;
using QuizGame.Data.Interfaces;
using QuizGame.Dtos;
using QuizGame.Enums;
using QuizGame.Requests;

namespace QuizGame.Controllers;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BoardsController : ControllerBase
{
    private readonly ILogger<BoardsController> _logger;
    private readonly IBoardRepo _boardRepo;
    private readonly IMapper _mapper;
    
    public BoardsController(ILogger<BoardsController> logger, IBoardRepo boardRepo, IMapper mapper)
    {
        _logger = logger;
        _boardRepo = boardRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BoardReadDto>> GetAllBoards()
    {
        var boards = _boardRepo.GetAllBoards();
        return Ok(_mapper.Map<IEnumerable<BoardReadDto>>(boards));
    }

    [HttpGet("{boardId}")]
    [CheckQueryString("space", false)]
    public ActionResult<BoardReadDto> GetBoardById(int boardId)
    {
        var board = _boardRepo.GetBoardById(boardId);
        if (board == null)
        {
            return NotFound($"Board with id {boardId} not found.");
        }

        return Ok(_mapper.Map<BoardReadDto>(board));
    }

    [HttpGet("{boardId}")]
    [CheckQueryString("space", true)]
    public ActionResult GetSpaceType(int boardId, [FromQuery(Name = "space")] int space)
    {
        var board = _boardRepo.GetBoardById(boardId);
        if (board == null)
        {
            return NotFound($"Board with id {boardId} not found.");
        }

        if (space >= board.BoardSize || space < 0)
        {
            return BadRequest("Invalid space");
        }

        SpaceType spaceType = (SpaceType) (board.Spaces[space] - '0');

        var returnLog = new
        {
            spaceType = spaceType
        };

        return Ok(returnLog);
    }
}