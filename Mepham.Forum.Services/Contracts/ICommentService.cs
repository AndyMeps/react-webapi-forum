using Mepham.Forum.Models.Entities;
using System;
using System.Collections.Generic;

namespace Mepham.Forum.Services.Contracts
{
    public interface ICommentService : IBaseService<Comment>
    {
        ICollection<Comment> GetByPostId(string id);
        ICollection<Comment> GetByPostId(Guid id);
    }
}
