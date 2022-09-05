using QuizGame.Models;

namespace QuizGame.Data;

public class GameRepo : IGameRepo
{
    private readonly AppDbContext _context;

    public GameRepo(AppDbContext context)
    {
        _context = context;
    }
    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }

    public IEnumerable<Game> GetAllGames()
    {
        return _context.Games.ToList();
    }

    public Game GetGameById(int gameId)
    {
        return _context.Games.FirstOrDefault(g => g.Id == gameId);
    }

    public void CreateGame(Game game)
    {
        if (game != null)
        {
            _context.Games.Add(game);
        }
        else
        {
            throw new ArgumentNullException(nameof(game));
        }
    }

    public bool GameExists(int gameId)
    {
        return _context.Games.Any(g => g.Id == gameId);
    }

    public IEnumerable<Player> GetPlayersForGame(int gameId)
    {
        return _context.Players.Where(p => p.GameId == gameId);
    }

    public void CreatePlayer(Player player)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }
        
        _context.Players.Add(player);
    }
}