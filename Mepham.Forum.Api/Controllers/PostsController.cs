using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Mepham.Forum.Models.Dtos.Post;
using Mepham.Forum.Services.Contracts;
using Mepham.Forum.Models.Entities;
using System.Linq;
using Mepham.Forum.Models.Dtos.Comment;

namespace Mepham.Forum.Api.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly ITopicService _topicService;
        private readonly ICommentService _commentService;

        public PostsController(IPostService threadService, IUserService userService, ITopicService topicService, ICommentService commentService)
        {
            _postService = threadService;
            _userService = userService;
            _topicService = topicService;
            _commentService = commentService;
        }

        /// <summary>
        /// Returns all Posts
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<BasicPostDto>> GetPosts()
        {
            var results = await _postService.GetAllAsync();

            return Mapper.Map<ICollection<BasicPostDto>>(results);
        }

        /// <summary>
        /// Returns a Post by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DetailedPostDto> GetPost(string id)
        {
            var result = await _postService.GetAsync(id);

            return Mapper.Map<DetailedPostDto>(result);
        }

        /// <summary>
        /// Creates a Post using the specified DTO.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Details of the Post if successful, otherwise a BadRequest with Detail.</returns>
        public IHttpActionResult CreatePost(CreatePostDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_userService.Get(model.AuthorId) == null) return BadRequest("User doesn't exist.");
            if (_topicService.Get(model.TopicId) == null) return BadRequest("Topic doesn't exist.");

            var post = _postService.Add(new Post
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                TopicId = model.TopicId,
                AuthorId = model.AuthorId,
                CreateDateTime = DateTime.Now
            });

            return Ok(Mapper.Map<BasicPostDto>(post));
        }

        /// <summary>
        /// Returns all Comments relating to a specified Post.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/Posts/{id}/Comments")]
        public IHttpActionResult GetPostComments(string id)
        {
            var result = _commentService.GetByPostId(id).Where(c => c.ResponseToCommentId == null);

            return Ok(Mapper.Map<ICollection<DetailedCommentDto>>(result));
        }
    }
}
