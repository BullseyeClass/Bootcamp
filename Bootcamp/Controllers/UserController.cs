using Bootcamp.Models.UserViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Bootcamp.Controllers
{
    public class UserController : Controller
    {
		[HttpGet]
		public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public IActionResult PostSignUp(UserView users)
		{
			if (!ModelState.IsValid)
			{
				return View("SignUp", users);
			}

			return RedirectToAction("SignUp Successful");
		}

	}
}
