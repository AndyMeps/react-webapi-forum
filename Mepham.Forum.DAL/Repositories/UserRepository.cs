using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Mepham.Forum.DAL.Contracts;
using Mepham.Forum.Models.Entities;

//https://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application

namespace Mepham.Forum.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IForumContext context) : base(context) { }

        /// <summary>
        /// Note: Overriding BaseRepository implementation as we want to Soft Delete Users.
        /// </summary>
        /// <param name="user"></param>
        public new int Delete(User user)
        {
            if (user == null) return -1;

            var expected = Context.Users.Find(user.Id);
            expected.DeleteDateTime = DateTime.Now;

            Context.Entry(expected).State = EntityState.Modified;
            return Context.SaveChanges();
        }

        /// <summary>
        /// Note: Overriding BaseRepository implementation as we want to soft delete Users.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public new Task<int> DeleteAsync(User user)
        {
            if (user == null) return null;

            var expected = Context.Users.FindAsync(user.Id).Result;
            expected.DeleteDateTime = DateTime.Now;

            Context.Entry(expected).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }
    }
}
