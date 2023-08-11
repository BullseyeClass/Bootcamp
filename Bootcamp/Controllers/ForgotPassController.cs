using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Controllers
{
    public class ForgotPassController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }



}
