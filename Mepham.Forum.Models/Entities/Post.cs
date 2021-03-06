﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mepham.Forum.Models.Entities
{
    /// <summary>
    /// A Post in a Topic, Users can Comment on Posts.
    /// </summary>
    public class Post : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public Guid TopicId { get; set; }

        #region Navigation Properties

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        #endregion

    }
}
