using QuizGame.Models;

namespace QuizGame.Data;

public interface IGameRepo
{
    bool SaveChanges();

    IEnumerable<Game> GetAllGames();

    void CreateGame(Game game);

    bool GameExists(int gameId);

    IEnumerable<Player> GetPlayersForGame(int gameId);

    void CreatePlayer(Player player);

    public Game GetGameById(int gameId);
}