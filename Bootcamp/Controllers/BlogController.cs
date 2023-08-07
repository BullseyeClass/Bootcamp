using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Controllers
{
    public class blogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
