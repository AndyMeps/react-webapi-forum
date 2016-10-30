using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using Mepham.Forum.Models.Dtos.User;
using Mepham.Forum.Services.Contracts;
using Mepham.Forum.Models.Entities;
using Mepham.Forum.Api.Helpers;

namespace Mepham.Forum.Api.Controllers
{
    [RoutePrefix("api/Auth")]
    public class AuthController : ApiController
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(LoginUserDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var foundUser = _userService.FindByUsername(model.Username);
            if (foundUser == null) return new NotFoundWithMessageResult("User doesn't exist.");
            if (foundUser.Password != model.Password) return BadRequest("Password incorrect.");

            return Ok(Mapper.Map<BasicUserDto>(foundUser));
        }

        [HttpPost]
        [Route("Register")]
        public IHttpActionResult Register(CreateUserDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_userService.FindByUsername(model.Username) != null)
                return BadRequest("Username already exists.");

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = model.Username,
                Password = model.Password,
                CreateDateTime = DateTime.Now
            };

            user = _userService.Add(user);

            return Ok(Mapper.Map<BasicUserDto>(user));
        }
    }
}
