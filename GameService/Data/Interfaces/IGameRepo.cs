using QuizGame.Enums;
using QuizGame.Models;

namespace QuizGame.Data.Interfaces;

public interface IGameRepo
{
    bool SaveChanges();

    IEnumerable<Game> GetAllGames();

    void CreateGame(Game game);

    bool GameExists(int gameId);

    public Game GetGameById(int gameId);

    public void SetGameState(Game game, State gameState);
}