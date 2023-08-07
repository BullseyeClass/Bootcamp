using Bootcamp.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Controllers
{
    public class LearnToCodeController : Controller
    {
        private readonly IGetBlogs _getBlogs;

        public LearnToCodeController(IGetBlogs getBlogs)
        {
            _getBlogs = getBlogs;
        }
        public IActionResult Index()
        {
            var blogs = _getBlogs.GetBlogsFromDB();
            return View(blogs.ToList());
        }
    }
}
