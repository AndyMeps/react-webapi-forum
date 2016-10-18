using System;
using System.ComponentModel.DataAnnotations;

namespace Mepham.Forum.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        // [Required]
        // public DateTime CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }
    }
}
