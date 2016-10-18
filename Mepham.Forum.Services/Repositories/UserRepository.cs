using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Mepham.Forum.Models;
using Mepham.Forum.Services.Contracts;

//https://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application

namespace Mepham.Forum.DAL.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly IForumContext _context;

        private bool _disposed;

        /// <summary>
        /// Constructor for UserRepository.
        /// </summary>
        /// <param name="context">Context on which this repository operates.</param>
        public UserRepository(IForumContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all users, can be filtered with LINQ.
        /// </summary>
        /// <returns>Zero to many users.</returns>
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        /// <summary>
        /// Looks for a user with the provided Id.
        /// </summary>
        /// <param name="id">Identifying column of the user.</param>
        /// <returns>Zero to 1 User</returns>
        public User FindById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Looks for a user with the provided Id, if found sets the user's DeleteDateTime = DateTime.Now otherwise returns.
        /// </summary>
        /// <param name="id">Identifying column of the user.</param>
        public void Delete(Guid id)
        {
            var user = _context.Users.Find(id);

            if (user == null) return;

            user.DeleteDateTime = DateTime.Now;
            _context.Entry(user).State = EntityState.Modified;
        }

        /// <summary>
        /// Updates the provided user.
        /// </summary>
        /// <param name="user">Modified existing user object.</param>
        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">New user object to be added.</param>
        public void Insert(User user)
        {
            _context.Users.Add(user);
        }

        /// <summary>
        /// Save changes made.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
