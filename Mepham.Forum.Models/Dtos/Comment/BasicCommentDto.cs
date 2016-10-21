using System;

namespace Mepham.Forum.Models.Dtos.Comment
{
    public class BasicCommentDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public Guid ThreadId { get; set; }
        public Guid? ResponseToCommentId { get; set; }
    }
}
