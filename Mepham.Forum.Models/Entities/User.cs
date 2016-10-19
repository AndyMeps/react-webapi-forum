using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mepham.Forum.Models.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        #region Navigation Properties

        public virtual ICollection<Topic> ModeratingTopics { get; set; }

        public virtual ICollection<Thread> AuthoredTopics { get; set; }

        #endregion
    }
}
