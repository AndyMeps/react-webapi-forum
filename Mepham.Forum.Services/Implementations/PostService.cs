using Mepham.Forum.DataAccess.Contracts;
using Mepham.Forum.Models.Entities;
using Mepham.Forum.Services.Contracts;

namespace Mepham.Forum.Services.Implementations
{
    public class PostService : BaseService<Post>, IPostService
    {
        public PostService(IForumContext context) : base(context) { }
    }
}
