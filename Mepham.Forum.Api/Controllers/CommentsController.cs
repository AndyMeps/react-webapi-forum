using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Mepham.Forum.Models.Dtos.Comment;
using Mepham.Forum.Services.Contracts;


namespace Mepham.Forum.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class CommentsController : ApiController
    {
        private readonly ICommentService _commentService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commentService"></param>
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<BasicCommentDto>> GetComments()
        {
            var results = await _commentService.GetAllAsync();

            return Mapper.Map<ICollection<BasicCommentDto>>(results);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BasicCommentDto> GetComment(string id)
        {
            var result = await _commentService.GetAsync(new Guid(id));

            return Mapper.Map<BasicCommentDto>(result);
        }
    }
}
