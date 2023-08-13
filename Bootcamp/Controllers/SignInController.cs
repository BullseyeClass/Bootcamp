using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Controllers
{
    public class SignInController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }

}
