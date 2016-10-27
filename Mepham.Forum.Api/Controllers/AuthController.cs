using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using Mepham.Forum.Models.Dtos.User;
using Mepham.Forum.Services.Contracts;

namespace Mepham.Forum.Api.Controllers
{
    public class AuthController : ApiController
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ActionName("Login")]
        public IHttpActionResult Login(LoginUserDto model)
        {
            var foundUser = _userService.Find(u => u.Username == model.Username);

            if (foundUser == null) return BadRequest();

            if (foundUser.Password != model.Password) return StatusCode(HttpStatusCode.Forbidden);

            return Ok(Mapper.Map<BasicUserDto>(foundUser));
        }
    }
}
