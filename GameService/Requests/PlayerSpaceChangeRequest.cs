using System.Text.Json.Serialization;

namespace QuizGame.Requests;

public class PlayerSpaceChangeRequest
{
    [JsonPropertyName("space")]
    public int Space { get; set; }
}