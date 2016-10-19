using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Mepham.Forum.DAL.Contracts;
using Mepham.Forum.Models.Dtos.Topic;

namespace Mepham.Forum.Api.Controllers
{
    public class TopicsController : ApiController
    {
        private readonly ITopicRepository _topicsRepository;

        public TopicsController(ITopicRepository topicsRepository)
        {
            _topicsRepository = topicsRepository;
        }

        public async Task<ICollection<BasicTopicDto>> GetAllTopics()
        {
            var result = await _topicsRepository.GetAllAsync();
            return Mapper.Map<ICollection<BasicTopicDto>>(result);
        }

        public async Task<BasicTopicDto> GetTopic(string id)
        {
            var result = await _topicsRepository.GetAsync(new Guid(id));
            return Mapper.Map<BasicTopicDto>(result);
        }
    }
}
