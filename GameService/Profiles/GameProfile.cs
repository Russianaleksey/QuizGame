using AutoMapper;
using QuizGame.Dtos;
using QuizGame.Models;

namespace QuizGame.Profiles;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<Game, GameReadDto>();
        CreateMap<GameCreateDto, Game>();
        CreateMap<Player, PlayerReadDto>();
        CreateMap<PlayerCreateDto, Player>();
        CreateMap<Board, BoardReadDto>();
        CreateMap<Question, QuestionReadDto>();
    }
}