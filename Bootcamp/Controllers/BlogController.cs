using Bootcamp.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using System.Linq;
using Bootcamp.Models;

namespace Bootcamp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IGetBlogs _getBlogs;

        public BlogController(IGetBlogs getBlogs)
        {
            _getBlogs = getBlogs;
        }
        //public IActionResult Index()
        //{
        //    var blogs = _getBlogs.GetBlogsFromDB();
        //    return View(blogs.ToList());
        //}

        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1; 
            int itemsPerPage = 10;

            var blogs = _getBlogs.GetBlogsFromDB().Result.Where(item => item.Category.Contains("Blog"));

            
            IPagedList<Blogs> pagedBlogs = blogs.ToPagedList(pageNumber, itemsPerPage);

            return View(pagedBlogs);
        }

        public IActionResult ReadMore(string id)
        {
            
            var blogEntry = _getBlogs.GetBlogsFromDB().Result.FirstOrDefault(item => item.Id == id);

            if (blogEntry == null)
            {
                return NotFound();
            }

            return View(blogEntry);
        }
    }
}