using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bootcamp.Models.SignInPage
{
    public class SignIn
    {
        [Required(ErrorMessage = "Email Required")]
        [DisplayName("Email*")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DisplayName("Password*")]
        public string Password { get; set; }
    }
}
