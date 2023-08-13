using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Controllers
{
    public class UserController : Controller
    {
		[HttpGet]
		public IActionResult Index()
        {
            return View();
        }
    }
}
