using Bootcamp.Models;
using Bootcamp.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Controllers
{
  
    public class TestController : Controller
    {
        private readonly IGetTest _getTest; 


        public TestController(IGetTest getTest)
        {
            this._getTest = getTest;
        }

        [HttpGet]
        public IActionResult GetHtmlTest()
        {
            ViewData["title"] = "Html Questions";
            var result = _getTest.GetHtmlQuestions();
            return View("Index", result);

        }

        [HttpPost]
        public ActionResult PostHtmlTest(List<Questions> questionList)
        {
            foreach(var questions in questionList)
            {
                foreach (var question in questions.Options)
                {
                    var text = question.Value.Text;
                    var isCorrect = question.Value.Correct;
                }
            }
            
            return RedirectToAction("Thank");
        }

        [HttpGet]
        public IActionResult GetCssTest()
        {
            ViewData["title"] = "Css Questions";

            var result = _getTest.GetCssQuestions();
            return View("Index", result);
        }

        [HttpGet]
        public IActionResult GetJsTest()
        {
            ViewData["title"] = "Javascript Questions";
            var result = _getTest.GetJsQuestions();
            return View("Index", result);
        }

        [HttpGet]
        public IActionResult ScoresView()
        {
            ViewData["title"] = "View";
           
            return View();
        }

    }
}
