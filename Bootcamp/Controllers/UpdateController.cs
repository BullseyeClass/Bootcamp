using Bootcamp.Models;
using Bootcamp.Models.ApiResponse;
using Bootcamp.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace Bootcamp.Controllers
{
    public class UpdateController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public UpdateController(IConfiguration configuration)
        {

            this._configuration = configuration;
            _baseUrl = _configuration["AppSettings:BaseUrl"];
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTrainee(TraineeUpdateDTO traineeUpdateDTO)
        {
            var userId = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var updateJson = JsonConvert.SerializeObject(traineeUpdateDTO);
                    var updateRequestBody = new StringContent(updateJson, System.Text.Encoding.UTF8, "application/json");

                    // Use HttpPutAsync to make a PUT request
                    var updateResponse = await httpClient.PutAsync($"{_baseUrl}/api/Trainee/updateTrainee/{userId}", updateRequestBody);

                    // ... Handle response and TempData messages as before
                    if (updateResponse.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Dashboard");
                        //var updateResponseData = await updateResponse.Content.ReadAsStringAsync();
                        //var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(updateResponseData);

                        //if (apiResponse.Success)
                        //{
                        //    TempData["UpdateSuccessMessage"] = "Trainee details updated successfully.";
                        //    return RedirectToAction("Index", "Dashboard"); // Redirect to appropriate view
                        //}
                        //else
                        //{
                        //    TempData["UpdateErrorMessage"] = "Error updating trainee details.";
                        //    return RedirectToAction("Index", "Error"); // Redirect to appropriate view
                        //}
                    }
                    else
                    {
                        TempData["UpdateErrorMessage"] = "Error communicating with the API.";
                        return RedirectToAction("Index", "Error"); // Redirect to appropriate view
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    TempData["ErrorMessage"] = "An error occurred during the update process.";
                    return RedirectToAction("Index", "Error"); // Redirect to appropriate view
                }
            }
            
        }
    }
}
