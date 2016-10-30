using Mepham.Forum.Models.Entities;

namespace Mepham.Forum.Services.Contracts
{
    /// <summary>
    /// Provides access to the Topic entity.
    /// </summary>
    public interface ITopicService : IBaseService<Topic> {

        /// <summary>
        /// Find a Topic by title, must be an exact match to return.
        /// </summary>
        /// <param name="title">Title of the topic to be found.</param>
        /// <returns></returns>
        Topic FindByTitle(string title);
    }
}
