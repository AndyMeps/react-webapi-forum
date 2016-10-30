using System;
using System.ComponentModel.DataAnnotations;

namespace Mepham.Forum.Models.Dtos.Post
{
    /// <summary>
    /// Class to be used when creating a Post.
    /// </summary>
    public class CreatePostDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public Guid TopicId { get; set; }
    }
}
