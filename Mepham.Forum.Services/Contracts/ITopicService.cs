using Mepham.Forum.Models.Entities;

namespace Mepham.Forum.Services.Contracts
{
    public interface ITopicService : IBaseService<Topic> {
        Topic FindByTitle(string title);
    }
}
