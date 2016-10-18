using System;
using System.Collections;
using System.Collections.Generic;
using Mepham.Forum.Dtos.User;
using Mepham.Forum.Models;

namespace Mepham.Forum.Services.Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User FindById(Guid id);
        void Delete(Guid id);
        void Update(User user);
        void Insert(User user);
        void Save();
    }
}
