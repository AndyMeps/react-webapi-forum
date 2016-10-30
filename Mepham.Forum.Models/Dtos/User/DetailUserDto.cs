using Mepham.Forum.Models.Dtos.Post;
using Mepham.Forum.Models.Dtos.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mepham.Forum.Models.Dtos.User
{
    /// <summary>
    /// Class to be used when an in-depth look at a User is required.
    /// </summary>
    public class DetailedUserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public ICollection<BasicTopicDto> ModeratingTopics { get; set; }
        public ICollection<BasicPostDto> AuthoredPosts { get; set; }
    }
}
