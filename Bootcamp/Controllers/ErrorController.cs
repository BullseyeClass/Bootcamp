﻿using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
