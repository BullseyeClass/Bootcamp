using Bootcamp.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IGetBlogs _getBlogs;

        public BlogController(IGetBlogs getBlogs)
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
