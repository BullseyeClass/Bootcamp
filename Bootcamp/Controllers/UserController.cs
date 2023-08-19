using Bootcamp.Models.UserViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace Bootcamp.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public UserController(IConfiguration configuration)
        {

            this._configuration = configuration;
            _baseUrl = _configuration["AppSettings:BaseUrl"];
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostSignUp(UserView users)
        {

            using (var httpClient = new HttpClient())
            {

                var json = JsonConvert.SerializeObject(users);
                var requestBody = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"{_baseUrl}/api/Trainee/register", requestBody);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    // Process the response from the API
                    return RedirectToAction("Index", "Breakinto");

                }
                else
                {
                    // Handle error case
                    return View();

                }
            }
        }

    }
}
