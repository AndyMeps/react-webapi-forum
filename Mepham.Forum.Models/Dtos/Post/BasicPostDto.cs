using System;

namespace Mepham.Forum.Models.Dtos.Post
{
    /// <summary>
    /// Class to be used when only a brief description of a Post is required.
    /// </summary>
    public class BasicPostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
