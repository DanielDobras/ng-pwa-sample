using System;
using Microsoft.AspNetCore.Mvc;
using Ng_Pwa_Sample_Backend.Web.Factory;

namespace Ng_Pwa_Sample_Backend.Web.Controllers
{
    [ApiController]
    [Route("api/questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly QuestionFactory _questionFactory;
        public QuestionsController()
        {
            _questionFactory = new QuestionFactory();
        }

        [HttpGet]
        public IActionResult GetQuestionsAsync(string difficulty)
        {
            if (String.IsNullOrEmpty(difficulty))
            {
                difficulty = "hard";
            }
            var questions = _questionFactory.GetQuestions(difficulty);

            return Ok(questions);
        }
    }
}
