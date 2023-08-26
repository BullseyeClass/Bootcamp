using Bootcamp.Models;
using Bootcamp.Models.Users;
using Bootcamp.Models.UserViewModel;
using Bootcamp.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Bootcamp.Controllers
{

    [Authorize]
    public class TestController : Controller
    {
		private readonly IGetTest _getTest;
		private readonly IConfiguration _configuration;
		private readonly string _baseUrl;

		public TestController(IGetTest getTest, IConfiguration configuration)
		{
			this._getTest = getTest;
			this._configuration = configuration; // Assign the parameter to the field
			_baseUrl = _configuration["AppSettings:BaseUrl"];
		}


		[HttpGet]
        public IActionResult GetHtmlTest()
        {
            ViewData["title"] = "Html Questions";
            var result = _getTest.GetHtmlQuestions();
            return View("Index", result);

        }

        [HttpPost]
        public async Task<IActionResult> PostHtmlTest(List<Questions> questionList, string selectedTestType)
        {
            List<Questions> result = new List<Questions>();

            if (selectedTestType == "Html")
            {
                result = _getTest.GetHtmlQuestions();
            }
            else if (selectedTestType == "Css")
            {
                result = _getTest.GetCssQuestions();
            }
            else if (selectedTestType == "Js")
            {
                result = _getTest.GetJsQuestions();
            }

            int score = 0;
            int index = 0;

            foreach (var question in result)
            {
                var selectedOptionKey = questionList[index].Options.FirstOrDefault().Key;

                if (question.Options.ContainsKey(selectedOptionKey))
                {
                    var selectedOption = question.Options[selectedOptionKey];
                    if (selectedOption.Correct)
                    {
                        score++;
                    }
                }

                index++;
            }

            var testScore = new TestResponseModel
            {                
                TestType = selectedTestType,
                Score = score,
            };

            try
            {
                using (var httpClient = new HttpClient())
                {
                    if (HttpContext.Request.Cookies.TryGetValue("token", out string token))
                    {
                        var json = JsonConvert.SerializeObject(testScore);
                        var requestBody = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
						httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
						HttpResponseMessage response = await httpClient.PostAsync($"{_baseUrl}/api/TestScore/post", requestBody);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();                            
                            return RedirectToAction("Index", "Dashboard");
                        }
                        else
                        {
                            // Handle error case
                            return RedirectToAction("Index", "Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return RedirectToAction("Index", "Error");
            }
            return View();
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
