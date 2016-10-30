using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mepham.Forum.Models.Entities
{
    /// <summary>
    /// Represents a section of the Forum, allows for Posts to be grouped in to relevant areas.
    /// A User will be defined as the Moderator when the Topic is created.
    /// </summary>
    public class Topic : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public Guid ModeratingUserId { get; set; }


        #region Navigation Properties

        [ForeignKey("ModeratingUserId")]
        public virtual User ModeratingUser { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        #endregion
    }
}
