using System;

namespace Mepham.Forum.Models.Dtos.Topic
{
    /// <summary>
    /// Class to be used when only a brief description of the Topic is required.
    /// </summary>
    public class BasicTopicDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
