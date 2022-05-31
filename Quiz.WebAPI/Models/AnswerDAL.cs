namespace Quiz.WebAPI.Models;

public class AnswerDAL
{
    public int QuestionId { get; set; }
    public string Answer { get; set; }
    public bool Correct { get; set; }
}