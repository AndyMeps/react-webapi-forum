using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Mepham.Forum.DAL.Contracts;
using Mepham.Forum.Models.Dtos.User;
using Mepham.Forum.Models.Entities;

namespace Mepham.Forum.Api.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ICollection<BasicUserDto>> GetAllUsers()
        {
            var result = await _userRepository.GetAllAsync();
            return Mapper.Map<ICollection<User>, ICollection<BasicUserDto>>(result);
        }

        public async Task<BasicUserDto> GetUser(string id)
        {
            var user = await _userRepository.GetAsync(new Guid(id));

            return Mapper.Map<BasicUserDto>(user);
        }
    }
}
