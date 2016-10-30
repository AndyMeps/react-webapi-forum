using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Mepham.Forum.Models.Dtos.User;
using Mepham.Forum.Models.Entities;
using Mepham.Forum.Services.Contracts;

namespace Mepham.Forum.Api.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userRepository;

        /// <param name="userRepository"></param>
        public UsersController(IUserService userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Returns all Users
        /// </summary>
        /// <returns>Returns all users.</returns>
        public async Task<ICollection<BasicUserDto>> GetAllUsers()
        {
            var result = await _userRepository.GetAllAsync();
            return Mapper.Map<ICollection<User>, ICollection<BasicUserDto>>(result);
        }

        /// <summary>
        /// Returns the User by Id
        /// </summary>
        /// <param name="id">Guid Id of the user to be returned.</param>
        /// <returns></returns>
        public async Task<BasicUserDto> GetUser(string id)
        {
            var user = await _userRepository.GetAsync(new Guid(id));

            return Mapper.Map<BasicUserDto>(user);
        }
    }
}
