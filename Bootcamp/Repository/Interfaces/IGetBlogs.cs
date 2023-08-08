using Bootcamp.Models;

namespace Bootcamp.Repository.Interfaces
{
    public interface IGetBlogs
    {
        IEnumerable<Blogs> GetBlogsFromDB();
    }
}
