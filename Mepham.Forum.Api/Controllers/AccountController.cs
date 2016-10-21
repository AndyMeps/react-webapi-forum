using System;
using System.Threading.Tasks;
using System.Web.Http;
using Mepham.Forum.Models.Dtos.User;
using Mepham.Forum.Models.Entities;
using Mepham.Forum.Services.Contracts;

namespace Mepham.Forum.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountController : ApiController
    {
        private readonly IUserService _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        public AccountController(IUserService userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Register(CreateUserDto userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userRepository.AddAsync(new User
                    {
                        Id = Guid.NewGuid(),
                        Username = userModel.Username,
                        Password = userModel.Password
                    });

            return Ok();
        }
    }
}
