namespace Bootcamp.Models
{
	public class TestResponseModel
	{
		public string TraineeId { get; set; }
		public string TestType { get; set; }
		public int Score { get; set; }
		public bool IsPassed
		{
			get
			{
				return Score < 11 ? true : false;
			}
		}
	}
}
