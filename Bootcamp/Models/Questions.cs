namespace Bootcamp.Models
{
    public class Questions
    {
        public string Question { get; set; }
        public Dictionary<string, Options> Options { get; set; }
    }

    public class Options
    {
        public string Text { get; set; }
        public bool Correct { get; set; }
    }

}
