using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Mepham.Forum.Models;

namespace Mepham.Forum.Services.Contracts
{
    public interface IForumContext : IDisposable
    {
        IDbSet<User> Users { get; set; }

        int SaveChanges();
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
