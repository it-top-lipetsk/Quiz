using Dapper;
using Microsoft.Data.Sqlite;
using Quiz.WebAPI.Models;

namespace Quiz.WebAPI.DB;

public static class DataBase
{
    private static string str = @"Data Source=D:\Programming\Education\ITStep\Lipetsk\Quiz\SQL\quiz.db";

    public static IEnumerable<QuestionModel> GetAllQuestions()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

        using var db = new SqliteConnection(str);

        var sql = "SELECT * FROM tab_questions";
        var questions = db.Query<QuestionDAL>(sql);

        sql = "SELECT question_id, answer, correct FROM tab_questions_answers JOIN tab_answers ON tab_questions_answers.answer_id = tab_answers.id";
        var answers = db.Query<AnswerDAL>(sql);

        var result = new List<QuestionModel>();
        foreach (var questionDal in questions)
        {
            var _answers = new List<AnswerModel>();
            foreach (var answerDal in answers)
            {
                if (answerDal.QuestionId == questionDal.Id)
                {
                    _answers.Add(new AnswerModel
                    {
                        Answer = answerDal.Answer,
                        Correct = answerDal.Correct
                    });
                }
            }
            result.Add(new QuestionModel
            {
                Question = questionDal.Question,
                Answers = _answers
            });
        }

        return result;
    }
}