using Mepham.Forum.DAL.Contracts;
using Mepham.Forum.Models.Entities;

namespace Mepham.Forum.DAL.Repositories
{
    public class TopicRepository : BaseRepository<Topic>, ITopicRepository
    {
        public TopicRepository(IForumContext context) : base(context) {  }
    }
}
