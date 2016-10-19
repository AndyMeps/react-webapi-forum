using System;
using System.Threading.Tasks;
using System.Web.Http;
using Mepham.Forum.DAL.Contracts;
using Mepham.Forum.Dtos.User;
using Mepham.Forum.Models;

namespace Mepham.Forum.Api.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

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
