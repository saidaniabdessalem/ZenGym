using System.ComponentModel.DataAnnotations;

namespace ZenGym.Application.Authentication
{
    public class UserForLoginDto
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}