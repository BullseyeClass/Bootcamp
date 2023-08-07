using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Controllers
{
    public class UIUXController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
