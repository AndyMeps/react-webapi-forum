using Mepham.Forum.DataAccess.Contracts;
using Mepham.Forum.Models.Entities;
using Mepham.Forum.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mepham.Forum.Services.Implementations
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        public CommentService(IForumContext context) : base(context) { }

        public ICollection<Comment> GetByPostId(string id)
        {
            return GetByPostId(new Guid(id));
        }

        public ICollection<Comment> GetByPostId(Guid id)
        {
            return FindAll(c => c.PostId == id && c.DeleteDateTime == null)
                        .OrderBy(c => c.CreateDateTime)
                        .ToList();
        }
    }
}
