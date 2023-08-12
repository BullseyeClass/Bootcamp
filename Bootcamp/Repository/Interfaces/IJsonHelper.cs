using Bootcamp.Models;

namespace Bootcamp.Repository.Interfaces
{
    public interface IJsonHelper
    {
        string Getpath(string fileName);
        List<Blogs> ReadFromJsons(string fullPath);
        public T ReadFromJson<T>(string fullPath);
    }
}
