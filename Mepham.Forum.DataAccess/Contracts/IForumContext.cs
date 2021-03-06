﻿using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Mepham.Forum.Models.Entities;

namespace Mepham.Forum.DataAccess.Contracts
{
    public interface IForumContext : IDisposable
    {
        DbSet<User> Users { get; set; }
        DbSet<Topic> Topics { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Comment> Comments { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
