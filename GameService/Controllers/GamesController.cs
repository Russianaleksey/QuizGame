﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizGame.Data;
using QuizGame.Dtos;
using QuizGame.Models;

namespace QuizGame.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    private readonly ILogger<GamesController> _logger;
    private readonly IMapper _mapper;
    private readonly IGameRepo _gameRepo;

    public GamesController(ILogger<GamesController> logger, IMapper mapper, IGameRepo gameRepo)
    {
        _logger = logger;
        _mapper = mapper;
        _gameRepo = gameRepo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<GameReadDto>> GetAllGames()
    {
        _logger.LogInformation("--> Request for all games came in");
        // TODO: Check for active games

        var games = _gameRepo.GetAllGames();
        return Ok(_mapper.Map<IEnumerable<GameReadDto>>(games));
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
                new { gameId = gameReadDto.Id }, gameReadDto);
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to create game. Error: {e.Message}");
            return BadRequest();
        }
    }
}