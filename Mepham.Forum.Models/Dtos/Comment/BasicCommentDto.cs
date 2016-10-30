using System;

namespace Mepham.Forum.Models.Dtos.Comment
{
    /// <summary>
    /// Class to be used when only a brief description of the Comment is needed.
    /// </summary>
    public class BasicCommentDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid? ResponseToCommentId { get; set; }
    }
}
