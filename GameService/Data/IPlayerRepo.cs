﻿using QuizGame.Models;

namespace QuizGame.Data;

public interface IPlayerRepo
{
    bool SaveChanges();

    Player GetPlayerById(int id);

    IEnumerable<Player> GetAllPlayers();

    void CreatePlayer(Player player);

    bool PlayerExists(int playerId);

    IEnumerable<Player> GetPlayersForGame(int gameId);

    void AssignPlayerToGame(int playerId, int gameId);
}