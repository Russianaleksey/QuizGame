using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizGame.Data;
using QuizGame.Dtos;
using QuizGame.Enums;
using QuizGame.Models;
using QuizGame.Requests;

namespace QuizGame.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    private readonly ILogger<GamesController> _logger;
    private readonly IMapper _mapper;
    private readonly IGameRepo _gameRepo;
    private readonly IPlayerRepo _playerRepo;
    
    public GamesController(ILogger<GamesController> logger, IMapper mapper, IGameRepo gameRepo, IPlayerRepo playerRepo)
    {
        _logger = logger;
        _mapper = mapper;
        _gameRepo = gameRepo;
        _playerRepo = playerRepo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<GameReadDto>> GetAllGames()
    {
        _logger.LogInformation("--> Request for all games came in");
        // TODO: Check for active games

        var games = _gameRepo.GetAllGames();
        return Ok(_mapper.Map<IEnumerable<GameReadDto>>(games));
    }

    [HttpGet("{gameId}/players")]
    public ActionResult<IEnumerable<PlayerReadDto>> GetPlayersForGame(int gameId)
    {
        var game = _gameRepo.GetGameById(gameId);
        if (game == null)
        {
            return NotFound();
        }

        var players = _playerRepo.GetPlayersForGame(gameId);
        return Ok(_mapper.Map<IEnumerable<PlayerReadDto>>(players));
    }

    [HttpGet("{gameId}", Name = "GetGameById")]
    public ActionResult<GameReadDto> GetGameById(int gameId)
    {
        var game = _gameRepo.GetGameById(gameId);
        if (game != null)
        {
            return Ok(_mapper.Map<GameReadDto>(game));
        }

        return NotFound();
    }

    [HttpPost]
    public ActionResult<GameReadDto> CreateGame(GameCreateDto gameDto)
    {
        var game = _mapper.Map<Game>(gameDto);
        try
        {
            _gameRepo.CreateGame(game);
            _gameRepo.SaveChanges();

            var gameReadDto = _mapper.Map<GameReadDto>(game);

            return CreatedAtRoute(nameof(GetGameById),
                new { gameId = gameReadDto.GameId }, gameReadDto);
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to create game. Error: {e.Message}");
            return BadRequest();
        }
    }
    
    [HttpPatch("{gameId}/players/{playerId}")]
    public ActionResult AddPlayerToGame(int playerId, int gameId)
    {
        try
        {
            _playerRepo.AssignPlayerToGame(playerId, gameId);
            _playerRepo.SaveChanges();
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError($"Unable to assign player {playerId} to game {gameId}. Error: {e.Message}");
            return BadRequest();
        }
    }

    [HttpPatch("{gameId}")]
    public ActionResult ChangeGameState(int gameId, [FromBody] GameStateChangeRequest stateChangeRequest)
    {
        var state = stateChangeRequest.State;
        
        var game = _gameRepo.GetGameById(gameId);
        if (game == null)
        {
            return NotFound($"Game with id {gameId} not found.");
        }

        if (game.State == State.Ended)
        {
            return Conflict("Cannot set state on game that has already ended");
        }
        
        if (state == State.NotStarted)
        {
            return Conflict("Cannot set state to NotStarted");
        }

        _gameRepo.SetGameState(game, state);
        _gameRepo.SaveChanges();
        
        return Ok("State successfully updated");
    }
}