using System.ComponentModel.DataAnnotations;

namespace Jwt.ViewModel
{
    public class LoginView
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }

    }
}
