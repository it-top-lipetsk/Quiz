namespace Quiz.WebAPI.Models;

public class QuestionModel
{
    public string Question { get; set; }
    public List<AnswerModel> Answers { get; set; }
}