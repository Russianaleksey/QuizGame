using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizGame.Data;
using QuizGame.Dtos;
using QuizGame.Models;

namespace QuizGame.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly ILogger<PlayersController> _logger;
    private readonly IMapper _mapper;
    private readonly IGameRepo _gameRepo;
    private readonly IPlayerRepo _playerRepo;
    
    public PlayersController(ILogger<PlayersController> logger, IMapper mapper, IGameRepo gameRepo, IPlayerRepo playerRepo)
    {
        _logger = logger;
        _mapper = mapper;
        _gameRepo = gameRepo;
        _playerRepo = playerRepo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlayerReadDto>> GetAllPlayers()
    {
        var players = _playerRepo.GetAllPlayers();
        return Ok(_mapper.Map<IEnumerable<PlayerReadDto>>(players));
    }

    [HttpGet("{playerId}", Name = "GetPlayerById")]
    public ActionResult<PlayerReadDto> GetPlayerById(int playerId)
    {
        var player = _playerRepo.GetPlayerById(playerId);
        if (player != null)
        {
            return Ok(_mapper.Map<PlayerReadDto>(player));
        }

        return NotFound();
    }

    [HttpPost]
    public ActionResult<PlayerReadDto> CreatePlayer(PlayerCreateDto playerCreateDto)
    {
        var player = _mapper.Map<Player>(playerCreateDto);
        try
        {
            _playerRepo.CreatePlayer(player);
            _playerRepo.SaveChanges();

            var playerReadDto = _mapper.Map<PlayerReadDto>(player);
            return CreatedAtRoute(nameof(GetPlayerById),
                new { playerId = playerReadDto.PlayerId }, playerReadDto);
        }
        catch (Exception e)
        {   
            _logger.LogError($"Unable to create player.");
            return BadRequest();
        }
    }
}