using Mepham.Forum.DataAccess.Contracts;
using Mepham.Forum.Models.Entities;
using Mepham.Forum.Services.Contracts;

namespace Mepham.Forum.Services.Implementations
{
    public class ThreadService : BaseService<Thread>, IThreadService
    {
        public ThreadService(IForumContext context) : base(context) { }
    }
}
