using System.Text.Json.Serialization;
using QuizGame.Enums;

namespace QuizGame.Requests;

public class GameStateChangeRequest
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public State State { get; set; }
}