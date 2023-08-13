using Bootcamp.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace Bootcamp.Models.UserViewModel
{
	public class UserView
	{
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Password is required")]
		[MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
		[RegularExpression(@"^(?=.*\d)(?=.*[a-zA-Z])(?=.*[@#$%^&+=])",
		ErrorMessage = "Password must contain at least one letter, one digit, and one special character")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Phone number is required")]
		[RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number format")]
		public List<PhoneNumber> PhoneNumber { get; set; } = new List<PhoneNumber>();
	}
}
