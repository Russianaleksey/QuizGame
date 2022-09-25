using QuizGame.Data.Interfaces;
using QuizGame.Enums;
using QuizGame.Models;

namespace QuizGame.Data;

public class BoardRepo : IBoardRepo
{
    private readonly AppDbContext _context;
    
    public BoardRepo(AppDbContext context)
    {
        _context = context;
    }
    
    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }

    public IEnumerable<Board> GetAllBoards()
    {
        return _context.Boards.ToList();
    }

    public Board GetBoardById(int boardId)
    {
        return _context.Boards.FirstOrDefault(b => b.BoardId == boardId);
    }

    public SpaceType GetSpaceType(Board board, int spaceIndex)
    {
        return (SpaceType)(board.Spaces[spaceIndex] - '0');
    }
}