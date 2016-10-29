using Mepham.Forum.Models.Dtos.Topic;
using System;
using System.Collections.Generic;

namespace Mepham.Forum.Models.Dtos.User
{
    public class BasicUserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}
