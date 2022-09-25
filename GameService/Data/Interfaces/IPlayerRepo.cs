using QuizGame.Models;

namespace QuizGame.Data.Interfaces;

public interface IPlayerRepo
{
    bool SaveChanges();

    Player GetPlayerById(int id);

    IEnumerable<Player> GetAllPlayers();

    void CreatePlayer(Player player);

    bool PlayerExists(int playerId);

    IEnumerable<Player> GetPlayersForGame(int gameId);

    void AssignPlayerToGame(Player player, Game game);

    void AssignPlayerToSpace(Player player, int space);
}