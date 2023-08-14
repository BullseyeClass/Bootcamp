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
		
		public string Password { get; set; }
		[Required(ErrorMessage = "Phone number is required")]
		
		public string PhoneNumber { get; set; }
	}
}
