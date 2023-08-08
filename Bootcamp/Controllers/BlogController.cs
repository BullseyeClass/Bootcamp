using Bootcamp.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace Bootcamp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IGetBlogs _getBlogs;

        public BlogController(IGetBlogs getBlogs)
        {
            _getBlogs = getBlogs;
        }

        public async Task<IActionResult> Index(string search, int? page)
        {
            var blogs = await _getBlogs.GetBlogsFromDB();

            int pageSize = 8;
            int pageNumber = page ?? 1;

            var pagedBlogs = blogs.ToPagedList(pageNumber, pageSize);

            return View(pagedBlogs);
        }
    }
}