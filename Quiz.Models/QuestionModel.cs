namespace Quiz.Models;

public class QuestionModel
{
    public string Question { get; set; }
    public List<AnswerModel> Answers { get; set; }
}