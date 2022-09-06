﻿using QuizGame.Models;

namespace QuizGame.Data;

public interface IGameRepo
{
    bool SaveChanges();

    IEnumerable<Game> GetAllGames();

    void CreateGame(Game game);

    bool GameExists(int gameId);

    public Game GetGameById(int gameId);
}