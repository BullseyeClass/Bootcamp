using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
