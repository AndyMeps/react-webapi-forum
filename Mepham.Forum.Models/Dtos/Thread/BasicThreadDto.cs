using System;

namespace Mepham.Forum.Models.Dtos.Thread
{
    public class BasicThreadDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AuthorUserId { get; set; }
        public Guid TopicId { get; set; }
    }
}
