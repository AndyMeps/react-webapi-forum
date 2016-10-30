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
    /// <summary>
    /// Provides authentication endpoints for the API
    /// </summary>
    [RoutePrefix("api/Auth")]
    public class AuthController : ApiController
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Used to validate against the system.
        /// </summary>
        /// <param name="model">The login object to be verified.</param>
        /// <returns>If successful the Username and Id of the user, otherwise a BadRequest with detail.</returns>
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

        /// <summary>
        /// Used to register a new User on the system.
        /// </summary>
        /// <param name="model">The registration object to be added to the system.</param>
        /// <returns>The Id and Username of the user if successful, otherwise a BadRequest with detail.</returns>
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
