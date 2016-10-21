using Mepham.Forum.DataAccess.Contracts;
using Mepham.Forum.Models.Entities;
using Mepham.Forum.Services.Contracts;

namespace Mepham.Forum.Services.Implementations
{
    public class TopicService : BaseService<Topic>, ITopicService
    {
        public TopicService(IForumContext context) : base(context) {  }
    }
}
