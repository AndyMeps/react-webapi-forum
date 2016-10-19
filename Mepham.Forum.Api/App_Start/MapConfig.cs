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
                cfg.CreateMap<Topic, BasicTopicDto>();
            });
        }
    }
}