﻿using System;

namespace Mepham.Forum.Models.Dtos.Post
{
    public class BasicPostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AuthorUserId { get; set; }
        public Guid TopicId { get; set; }
    }
}