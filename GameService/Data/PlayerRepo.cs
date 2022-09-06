using System.Data;
using QuizGame.Enums;
using QuizGame.Models;

namespace QuizGame.Data;

public class PlayerRepo : IPlayerRepo
{
    private readonly AppDbContext _context;

    public PlayerRepo(AppDbContext context)
    {
        _context = context;
    }
    
    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }

    public IEnumerable<Player> GetAllPlayers()
    {
        return _context.Players.ToList();
    }

    public Player GetPlayerById(int playerId)
    {
        return _context.Players.FirstOrDefault(p => p.PlayerId == playerId);
    }

    public IEnumerable<Player> GetPlayersForGame(int gameId)
    {
        return _context.Players.Where(p => p.GameId == gameId);
    }

    public void CreatePlayer(Player player)
    {
        if (player != null)
        {
            _context.Players.Add(player);
        }
        else
        {
            throw new ArgumentNullException();
        }
    }

    public bool PlayerExists(int playerId)
    {
        return _context.Players.Any(p => p.PlayerId == playerId);
    }

    public void AssignPlayerToGame(int playerId, int gameId)
    {
        var player = _context.Players.FirstOrDefault(p => p.PlayerId == playerId);
        var game = _context.Games.FirstOrDefault(g => g.GameId == gameId);
        if (player == null || game == null)
        {
            throw new ArgumentNullException();
        }

        if (game.State != State.NotStarted)
        {
            throw new ConstraintException($"Adding player {playerId} to game {gameId} failed. Game already started or ended.");
        }
        else
        {
            player.GameId = gameId;
            _context.SaveChanges();
        }
    }
}