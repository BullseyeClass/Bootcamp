namespace Bootcamp.Models.Dashboard
{
    public class DashBoard
    {
        public string TestType { get; set; } = string.Empty;
        public string Score { get; set; } = string.Empty;   
        public bool IsPassed { get; set; }
        public DateTime Date { get; set; }
    }
}
