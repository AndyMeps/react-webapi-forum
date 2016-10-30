using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Mepham.Forum.Models.Dtos.Post;
using Mepham.Forum.Services.Contracts;
using Mepham.Forum.Models.Entities;

namespace Mepham.Forum.Api.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly ITopicService _topicService;

        public PostsController(IPostService threadService, IUserService userService, ITopicService topicService)
        {
            _postService = threadService;
            _userService = userService;
            _topicService = topicService;
        }

        public async Task<ICollection<BasicPostDto>> GetPosts()
        {
            var results = await _postService.GetAllAsync();

            return Mapper.Map<ICollection<BasicPostDto>>(results);
        }

        public async Task<DetailedPostDto> GetPost(string id)
        {
            var result = await _postService.GetAsync(new Guid(id));

            return Mapper.Map<DetailedPostDto>(result);
        }

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
    }
}
