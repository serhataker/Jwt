using System.ComponentModel.DataAnnotations;

namespace Jwt.ViewModel
{
    public class UserView
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }
    }
}
