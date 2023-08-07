namespace Bootcamp.Models
{
    public class Blogs
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string[] Category { get; set; }
        public string[]? SubCategory { get; set; }
        public string Link { get; set; }
        public bool StartHere { get; set; }
        public bool MostRecent { get; set; }
    }
}
