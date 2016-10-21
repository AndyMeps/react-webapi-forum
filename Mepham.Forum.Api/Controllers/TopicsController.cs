using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Mepham.Forum.Models.Dtos.Topic;
using Mepham.Forum.Services.Contracts;

namespace Mepham.Forum.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TopicsController : ApiController
    {
        private readonly ITopicService _topicsRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="topicsRepository"></param>
        public TopicsController(ITopicService topicsRepository)
        {
            _topicsRepository = topicsRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns all topics.</returns>
        public async Task<ICollection<BasicTopicDto>> GetAllTopics()
        {
            var result = await _topicsRepository.GetAllAsync();
            return Mapper.Map<ICollection<BasicTopicDto>>(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Guid Id of the Topic to be returned.</param>
        /// <returns></returns>
        public async Task<BasicTopicDto> GetTopic(string id)
        {
            var result = await _topicsRepository.GetAsync(new Guid(id));
            return Mapper.Map<BasicTopicDto>(result);
        }
    }
}
