using Bootcamp.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Controllers
{
  
    public class Test : Controller
    {
        private readonly IGetTest _getTest;

        public Test(IGetTest getTest)
        {
            this._getTest = getTest;
        }

        [HttpGet]
        public IActionResult GetHtmlTest()
        {

            return View(_getTest.GetHtmlQuestions());

        }
    }
}
