using Dapper;
using Microsoft.Data.Sqlite;
using Quiz.WebAPI.Models;

namespace Quiz.WebAPI.DB;

public class DataBase
{
    private const string str = "Data Source=usersdata.db";

    public IEnumerable<QuestionModel> GetAllQuestions()
    {
        using var db = new SqliteConnection(str);
        var sql = "SELECT question, answer, correct FROM tab_questions_answers JOIN tab_questions ON tab_questions_answers.question_id = tab_questions.id JOIN tab_answers ON tab_questions_answers.answer_id = tab_answers.id";
        return db.Query<QuestionModel>(sql);
    }
}