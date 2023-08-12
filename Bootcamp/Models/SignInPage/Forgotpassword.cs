using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bootcamp.Models.SignInPage
{
    public class Forgotpassword
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        [DisplayName("Email*")]
        public string Email { get; set; }

        [Required(ErrorMessage = "New Password Required")]
        [DisplayName("New Password*")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password Required")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
        [DisplayName("Confirm Password*")]
        public string ConfirmPassword { get; set; }
    }
}
