using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mepham.Forum.DataAccess.Contracts;

namespace Mepham.Forum.Services.Implementations
{
    /// <summary>
    /// Boilerplate repository that handles the majority of the needs of every Entity repository.
    /// </summary>
    /// <typeparam name="TObject">POCO from Mepham.Forum.Models</typeparam>
    public class BaseService<TObject> where TObject : class
    {
        protected IForumContext Context;

        public BaseService(IForumContext context)
        {
            Context = context;
        }

        public ICollection<TObject> GetAll()
        {
            return Context.Set<TObject>().ToList();
        }

        public async Task<ICollection<TObject>> GetAllAsync()
        {
            return await Context.Set<TObject>().ToListAsync();
        }

        public TObject Get(Guid id)
        {
            return Context.Set<TObject>().Find(id);
        }

        public async Task<TObject> GetAsync(Guid id)
        {
            return await Context.Set<TObject>().FindAsync(id);
        }

        public TObject Find(Expression<Func<TObject, bool>> match)
        {
            return Context.Set<TObject>().SingleOrDefault(match);
        }

        public async Task<TObject> FindAsync(Expression<Func<TObject, bool>> match)
        {
            return await Context.Set<TObject>().SingleOrDefaultAsync(match);
        }

        public ICollection<TObject> FindAll(Expression<Func<TObject, bool>> match)
        {
            return Context.Set<TObject>().Where(match).ToList();
        }

        public async Task<ICollection<TObject>> FindAllAsync(Expression<Func<TObject, bool>> match)
        {
            return await Context.Set<TObject>().Where(match).ToListAsync();
        }

        public TObject Add(TObject t)
        {
            Context.Set<TObject>().Add(t);
            Context.SaveChanges();
            return t;
        }

        public async Task<TObject> AddAsync(TObject t)
        {
            Context.Set<TObject>().Add(t);
            await Context.SaveChangesAsync();
            return t;
        }

        public TObject Update(TObject updated, Guid key)
        {
            if (updated == null) return null;

            TObject existing = Context.Set<TObject>().Find(key);

            if (existing != null)
            {
                Context.Entry(existing).CurrentValues.SetValues(updated);
                Context.SaveChanges();
            }
            return existing;
        }

        public async Task<TObject> UpdateAsync(TObject updated, Guid key)
        {
            if (updated == null) return null;

            TObject existing = await Context.Set<TObject>().FindAsync(key);

            if (existing != null)
            {
                Context.Entry(existing).CurrentValues.SetValues(updated);
                await Context.SaveChangesAsync();
            }

            return existing;
        }

        public int Delete(TObject t)
        {
            Context.Set<TObject>().Remove(t);
            return Context.SaveChanges();
        }

        public async Task<int> DeleteAsync(TObject t)
        {
            Context.Set<TObject>().Remove(t);
            return await Context.SaveChangesAsync();
        }

        public int Count()
        {
            return Context.Set<TObject>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await Context.Set<TObject>().CountAsync();
        }
    }
}
