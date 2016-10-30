using AutoMapper;
using Mepham.Forum.Models.Dtos.Comment;
using Mepham.Forum.Models.Dtos.Post;
using Mepham.Forum.Models.Dtos.Topic;
using Mepham.Forum.Models.Dtos.User;
using Mepham.Forum.Models.Entities;

namespace Mepham.Forum.Api
{
    public static class MapConfig
    {

        public static void CreateAutoMapperMappings()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, BasicUserDto>();
                cfg.CreateMap<User, DetailedUserDto>();
                cfg.CreateMap<Topic, BasicTopicDto>();
                cfg.CreateMap<Topic, DetailedTopicDto>();
                cfg.CreateMap<Post, BasicPostDto>();
                cfg.CreateMap<Post, DetailedPostDto>();
                cfg.CreateMap<Comment, BasicCommentDto>();
                cfg.CreateMap<Comment, DetailedCommentDto>();
            });
        }
    }
}