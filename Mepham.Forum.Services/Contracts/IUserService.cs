using Mepham.Forum.Models.Entities;

namespace Mepham.Forum.Services.Contracts
{
    /// <summary>
    /// Provides access to the User entity.
    /// </summary>
    public interface IUserService : IBaseService<User> {

        /// <summary>
        /// Find a User by Username, must be an exact match to return.
        /// </summary>
        /// <param name="username">Username of the user to be found.</param>
        /// <returns></returns>
        User FindByUsername(string username);
    }
}
