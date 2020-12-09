using System.ComponentModel.DataAnnotations;

namespace ZenGym.Application.Authentication
{
    public class UserForRegisterDto
    {
        private const string passwordErrorMessage = "You must specify password between 4 and 8 characters";

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = passwordErrorMessage)]
        public string Password { get; set; }
    }
}