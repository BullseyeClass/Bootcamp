namespace Bootcamp.Models.ApiResponse
{
	public class PhoneNumber
	{
		public string Extension { get; set; }
		public string Number { get; set; }
	}

	public class Address
	{
		public string PostalCode { get; set; }
		public string MainAddress { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
	}

	public class Test
	{
		public int? Id { get; set; }
		public string TestType { get; set; }
		public int Score { get; set; }
		public bool IsPassed { get; set; }
	}

	public class ApiResponseModel
	{
		public Guid TraineeId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public List<PhoneNumber> PhoneNumbers { get; set; }
		public List<Address> Addresses { get; set; }
		public List<Test> Tests { get; set; }
	}
}
