using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Mepham.Forum.Models.Dtos.Thread;
using Mepham.Forum.Services.Contracts;

namespace Mepham.Forum.Api.Controllers
{
    public class ThreadsController : ApiController
    {
        private readonly IThreadService _threadService;

        public ThreadsController(IThreadService threadService)
        {
            _threadService = threadService;
        }

        public async Task<ICollection<BasicThreadDto>> GetThreads()
        {
            var results = await _threadService.GetAllAsync();

            return Mapper.Map<ICollection<BasicThreadDto>>(results);
        }

        public async Task<BasicThreadDto> GetThread(string id)
        {
            var result = await _threadService.GetAsync(new Guid(id));

            return Mapper.Map<BasicThreadDto>(result);
        }
    }
}
