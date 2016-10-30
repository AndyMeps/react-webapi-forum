using Mepham.Forum.Models.Dtos.Topic;
using Mepham.Forum.Models.Dtos.User;
using System;

namespace Mepham.Forum.Models.Dtos.Post
{
    public class DetailedPostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BasicUserDto Author { get; set; }
        public BasicTopicDto Topic { get; set; }
    }
}
