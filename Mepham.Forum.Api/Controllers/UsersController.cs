using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Mepham.Forum.Dtos.User;
using Mepham.Forum.Models;
using Mepham.Forum.Services.Contracts;

namespace Mepham.Forum.Api.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<BasicUserDto> GetAllUsers()
        {
            return Mapper.Map<IEnumerable<User>, IEnumerable<BasicUserDto>>(_userRepository.GetUsers());
        }

        public BasicUserDto GetUser(string id)
        {
            var user = _userRepository.FindById(new Guid(id));

            return Mapper.Map<BasicUserDto>(user);
        }
    }
}
