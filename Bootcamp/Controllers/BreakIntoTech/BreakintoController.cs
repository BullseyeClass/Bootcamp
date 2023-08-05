using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Controllers.BreakIntoTech
{
    public class BreakintoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
