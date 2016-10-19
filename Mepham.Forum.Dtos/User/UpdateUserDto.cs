using System;
using System.ComponentModel.DataAnnotations;

namespace Mepham.Forum.Dtos.User
{
    public class UpdateUserDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is a required field.")]
        [MinLength(4, ErrorMessage = "Username must be longer than 3 characters.")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is a required field.")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Confirmation is a required field.")]
        [Compare(nameof(Password), ErrorMessage = "Passwords must match.")]
        public string PasswordConfirm { get; set; }
    }
}
