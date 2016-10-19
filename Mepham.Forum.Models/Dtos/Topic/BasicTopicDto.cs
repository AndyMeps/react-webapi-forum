using System;

namespace Mepham.Forum.Models.Dtos.Topic
{
    public class BasicTopicDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
