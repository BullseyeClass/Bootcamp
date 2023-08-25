using Bootcamp.Models.UserViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;

namespace Bootcamp.Controllers
{
    public class DashboardController : Controller
	{
		private readonly IConfiguration _configuration;
		private readonly string _baseUrl;



		public DashboardController(IConfiguration configuration)
		{
			_configuration = configuration;
			_baseUrl = _configuration["AppSettings:BaseUrl"];
		}
		public async Task<IActionResult> Index()
		{
			var userId = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;
			using (var httpClient = new HttpClient())
			{
				try
				{
					HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/GetUser/{userId}");
					if (response.IsSuccessStatusCode)
					{
						string responseBody = await response.Content.ReadAsStringAsync();
						ApiResponseModel traineeDetails = JsonConvert.DeserializeObject<ApiResponseModel>(responseBody);
						//var details = traineeDetails.Where(x => x.TraineeId == Guid.Parse(userId));
						return View(traineeDetails);
					}
					else
					{
						//Handle error case
						return RedirectToAction("Index", "Error");
					}
				}
				catch (Exception ex)
				{
					return RedirectToAction("Index", "Error");
				}
				
			}
		}
	}
}
