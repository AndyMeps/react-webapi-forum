using System;
using System.Data.Entity;
using Mepham.Forum.Models;
using Mepham.Forum.Services.Contracts;

namespace Mepham.Forum.DAL
{
    public class ForumContext : DbContext, IForumContext, IDisposable
    {
        public virtual IDbSet<User> Users { get; set; }
    }
}
