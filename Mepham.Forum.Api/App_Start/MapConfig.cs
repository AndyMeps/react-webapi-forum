using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mepham.Forum.Dtos.User;
using Mepham.Forum.Models;

namespace Mepham.Forum.Api.App_Start
{
    public static class MapConfig
    {

        public static void CreateAutoMapperMappings()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, BasicUserDto>();
            });
        }
    }
}