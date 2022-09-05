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
        return _context.Players.FirstOrDefault(p => p.Id == playerId);
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
        return _context.Players.Any(p => p.Id == playerId);
    }

    public void AssignPlayerToGame(int playerId, int gameId)
    {
        var player = _context.Players.FirstOrDefault(p => p.Id == playerId);
        var game = _context.Games.FirstOrDefault(g => g.Id == gameId);
        if (player != null && game != null)
        {
            player.Game = game;
            
        }
        else
        {
            throw new ArgumentNullException();
        }
    }
}