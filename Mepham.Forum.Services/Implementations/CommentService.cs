using Mepham.Forum.DataAccess.Contracts;
using Mepham.Forum.Models.Entities;
using Mepham.Forum.Services.Contracts;

namespace Mepham.Forum.Services.Implementations
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        public CommentService(IForumContext context) : base(context) { }
    }
}
