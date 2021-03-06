﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mepham.Forum.Models.Dtos.Comment
{
    /// <summary>
    /// Class to be used when creating a Comment.
    /// </summary>
    public class CreateCommentDto
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public Guid PostId { get; set; }

        public Guid? ResponseToCommentId { get; set; }
    }
}
