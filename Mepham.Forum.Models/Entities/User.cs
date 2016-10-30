using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mepham.Forum.Models.Entities
{
    /// <summary>
    /// Is a user of the system, can create Topics, Posts and Comments. 
    /// Will be defined as a Moderator when creating a Topic and an Author 
    /// when creating a Post / Comment
    /// </summary>
    public class User : BaseEntity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        #region Navigation Properties

        public virtual ICollection<Topic> ModeratingTopics { get; set; }

        public virtual ICollection<Post> AuthoredPosts { get; set; }

        public virtual ICollection<Comment> AuthoredComments { get; set; }

        #endregion
    }
}
