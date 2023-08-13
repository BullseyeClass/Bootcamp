using Bootcamp.Models;
using Bootcamp.Repository.Interfaces;
using System.Text.Json;

namespace Bootcamp.Repository.Helper
{
    public class JsonHelper : IJsonHelper
    {
        public string Getpath(string fileName)
        {
            string currentDir = Environment.CurrentDirectory;
            string folderPath =Path.GetFullPath(Path.Combine(currentDir, @"JsonData"));
            string filePath = Path.Combine(folderPath, fileName);
            return filePath;
        }

        public List<Blogs> ReadFromJsons(string fullPath)
        {
            fullPath = Getpath("blogdata.json");
            string jsonContent = File.ReadAllText(fullPath);
            return JsonSerializer.Deserialize<List<Blogs>>(jsonContent);
        }

        public List<Questions> ReadFromJson(string fileName)
        {
            string jsonContent = File.ReadAllText(Getpath(fileName));
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                ReadCommentHandling = JsonCommentHandling.Skip
            };

            return JsonSerializer.Deserialize<List<Questions>>(jsonContent, options);
        }

    }
}
