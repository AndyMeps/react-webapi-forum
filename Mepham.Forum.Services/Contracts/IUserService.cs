using Mepham.Forum.Models.Entities;

namespace Mepham.Forum.Services.Contracts
{
    public interface IUserService : IBaseService<User> {
        User FindByUsername(string username);
    }
}
