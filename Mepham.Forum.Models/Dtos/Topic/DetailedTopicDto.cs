using Mepham.Forum.Models.Dtos.Post;
using Mepham.Forum.Models.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mepham.Forum.Models.Dtos.Topic
{
    /// <summary>
    /// Class to be used when an in-depth model of a topic is required.
    /// </summary>
    public class DetailedTopicDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BasicUserDto ModeratingUser { get; set; }
        public ICollection<BasicPostDto> Posts { get; set; }
    }
}
