using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Mepham.Forum.Models.Dtos.Post;
using Mepham.Forum.Services.Contracts;

namespace Mepham.Forum.Api.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IPostService _threadService;

        public PostsController(IPostService threadService)
        {
            _threadService = threadService;
        }

        public async Task<ICollection<BasicPostDto>> GetThreads()
        {
            var results = await _threadService.GetAllAsync();

            return Mapper.Map<ICollection<BasicPostDto>>(results);
        }

        public async Task<BasicPostDto> GetThread(string id)
        {
            var result = await _threadService.GetAsync(new Guid(id));

            return Mapper.Map<BasicPostDto>(result);
        }
    }
}
