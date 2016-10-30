using System.ComponentModel.DataAnnotations;

namespace Mepham.Forum.Models.Dtos.User
{
    /// <summary>
    /// Class to be used when logging in a User.
    /// </summary>
    public class LoginUserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
