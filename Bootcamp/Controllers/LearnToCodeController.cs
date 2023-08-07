using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Controllers
{
    public class LearnToCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
