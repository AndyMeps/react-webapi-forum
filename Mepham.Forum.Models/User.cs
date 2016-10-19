using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mepham.Forum.Models
{
    public class User
    {
        [Key]
        [DefaultValue("NEWID()")]
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [DefaultValue("GETDATE()")]
        public DateTime CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }
    }
}
