using System.Text.Json.Serialization;

namespace Quiz.Models;

public class AnswerModel
{
    [JsonPropertyName("answer")]
    public string Answer { get; set; }
    
    [JsonPropertyName("correct")]
    public bool Correct { get; set; }
}