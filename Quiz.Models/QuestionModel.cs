using System.Text.Json.Serialization;

namespace Quiz.Models;

public class QuestionModel
{
    [JsonPropertyName("question")]
    public string Question { get; set; }
    
    [JsonPropertyName("answers")]
    public List<AnswerModel> Answers { get; set; }
}