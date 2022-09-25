using QuizGame.Enums;
using QuizGame.Models;

namespace QuizGame.Data.Interfaces;

public interface IBoardRepo
{
    bool SaveChanges();

    Board GetBoardById(int boardId);

    IEnumerable<Board> GetAllBoards();
    SpaceType GetSpaceType(Board board, int spaceIndex);
}