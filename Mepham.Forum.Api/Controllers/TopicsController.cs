using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Mepham.Forum.Models.Dtos.Topic;
using Mepham.Forum.Services.Contracts;
using Mepham.Forum.Models.Entities;

namespace Mepham.Forum.Api.Controllers
{
    public class TopicsController : ApiController
    {
        private readonly ITopicService _topicService;
        private readonly IUserService _userService;

        public TopicsController(ITopicService topicService, IUserService userService)
        {
            _topicService = topicService;
            _userService = userService;
        }

        /// <summary>
        /// Returns all Topics
        /// </summary>
        /// <returns>Returns all topics.</returns>
        public async Task<ICollection<BasicTopicDto>> GetAllTopics()
        {
            var result = await _topicService.GetAllAsync();
            return Mapper.Map<ICollection<BasicTopicDto>>(result);
        }

        /// <summary>
        /// Returns a Topic by Id
        /// </summary>
        /// <param name="id">Guid Id of the Topic to be returned.</param>
        /// <returns></returns>
        public async Task<DetailedTopicDto> GetTopic(string id)
        {
            var result = await _topicService.GetAsync(new Guid(id));
            return Mapper.Map<DetailedTopicDto>(result);
        }

        /// <summary>
        /// Creates a Topic using the provided DTO
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Basic Topic details if successful, otherwise a BadRequest with detail.</returns>
        [HttpPost]
        public IHttpActionResult CreateTopic(CreateTopicDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_topicService.FindByTitle(model.Title) != null)
                return BadRequest("Topic already exists");
            if (_userService.Get(model.ModeratingUserId) == null)
                return BadRequest("User not found.");

            var topic = _topicService.Add(new Topic {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                ModeratingUserId = model.ModeratingUserId,
                CreateDateTime = DateTime.Now
            });

            return Ok(Mapper.Map<BasicTopicDto>(topic));
        }
    }
}
