using Mepham.Forum.DAL.Contracts;
using Mepham.Forum.Models.Entities;

namespace Mepham.Forum.DAL.Repositories
{
    public class ThreadRepository : BaseRepository<Thread>, IThreadRepository
    {
        public ThreadRepository(IForumContext context) : base(context) { }
    }
}
