using System.ComponentModel.DataAnnotations;

namespace Mepham.Forum.Models.Dtos.User
{
    /// <summary>
    /// Class to be used when creating a User.
    /// </summary>
    public class CreateUserDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is a required field.")]
        [MinLength(4, ErrorMessage = "Username must be longer than 3 characters.")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is a required field.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Confirmation is a required field.")]
        [Compare(nameof(Password), ErrorMessage = "Passwords must match.")]
        [MinLength(6, ErrorMessage = "Password Confirmation must be at least 6 characters long.")]
        public string PasswordConfirm { get; set; }
    }
}
