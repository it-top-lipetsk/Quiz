using Microsoft.AspNetCore.Mvc;
using Quiz.WebAPI.DB;

namespace Quiz.WebAPI.Controllers;

[ApiController]
[Route("api/v1/questions")]
public class QuestionsController : ControllerBase
{
    [HttpGet]
    public JsonResult GetAllTasks()
    {
        return new JsonResult(DataBase.GetAllQuestions());
    }
}