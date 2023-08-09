using Bootcamp.Models;
using Bootcamp.Repository.Interfaces;
using System.Threading.Tasks;

namespace Bootcamp.Services
{
    public class GetBlogs : IGetBlogs
    {
        private readonly IJsonHelper _jsonHelper;
        private readonly IHostEnvironment _hostEnvironment;

        public GetBlogs(IJsonHelper jsonHelper, IHostEnvironment hostEnvironment)
        {
            _jsonHelper = jsonHelper;
            _hostEnvironment = hostEnvironment;
        }

        public Task<IEnumerable<Blogs>> GetBlogsFromDB()
        {
            string filePath = Path.Combine(_hostEnvironment.ContentRootPath, "JsonData", "blogdata.json");
            IEnumerable<Blogs> blogs = _jsonHelper.ReadFromJsons(filePath);
            return Task.FromResult(blogs);
        }
    }
}
