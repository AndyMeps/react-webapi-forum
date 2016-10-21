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
    /// <summary>
    /// 
    /// </summary>
    public class UsersController : ApiController
    {
        private readonly IUserService _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        public UsersController(IUserService userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns all users.</returns>
        public async Task<ICollection<BasicUserDto>> GetAllUsers()
        {
            var result = await _userRepository.GetAllAsync();
            return Mapper.Map<ICollection<User>, ICollection<BasicUserDto>>(result);
        }

        /// <summary>
        /// 
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
