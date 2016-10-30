using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Mepham.Forum.Models.Dtos.Comment;
using Mepham.Forum.Services.Contracts;
using Mepham.Forum.Models.Entities;

namespace Mepham.Forum.Api.Controllers
{
    public class CommentsController : ApiController
    {
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public CommentsController(ICommentService commentService, IPostService postService, IUserService userService)
        {
            _commentService = commentService;
            _postService = postService;
            _userService = userService;
        }

        /// <summary>
        /// Return a brief description of all Comments.
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<BasicCommentDto>> GetComments()
        {
            var results = await _commentService.GetAllAsync();

            return Mapper.Map<ICollection<BasicCommentDto>>(results);
        }

        /// <summary>
        /// Return a Comment by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BasicCommentDto> GetComment(string id)
        {
            var result = await _commentService.GetAsync(new Guid(id));

            return Mapper.Map<BasicCommentDto>(result);
        }

        /// <summary>
        /// Creates a new Comment on the system.
        /// </summary>
        /// <param name="model">The comment to be created.</param>
        /// <returns>Basic details of the Comment if successful, otherwise a BadRequest with detail.</returns>
        public IHttpActionResult CreateComment(CreateCommentDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_userService.Get(model.AuthorId) == null) return BadRequest("User not found.");
            if (_postService.Get(model.PostId) == null) return BadRequest("Post not found.");

            try
            {
                var comment = _commentService.Add(new Comment
                {
                    Id = Guid.NewGuid(),
                    Description = model.Description,
                    PostId = model.PostId,
                    AuthorId = model.AuthorId,
                    ResponseToCommentId = model.ResponseToCommentId,
                    CreateDateTime = DateTime.Now
                });

                if(comment.Author == null)
                {
                    comment.Author = _userService.Get(comment.AuthorId);
                }

                return Ok(Mapper.Map<DetailedCommentDto>(comment));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
