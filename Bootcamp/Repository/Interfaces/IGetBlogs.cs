using Bootcamp.Models;

namespace Bootcamp.Repository.Interfaces
{
    public interface IGetBlogs
    {
        Task<IEnumerable<Blogs>> GetBlogsFromDB();
    }
}
