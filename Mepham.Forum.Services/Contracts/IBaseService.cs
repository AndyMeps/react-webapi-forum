using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mepham.Forum.Services.Contracts
{
    public interface IBaseService<TObject> where TObject : class
    {
        ICollection<TObject> GetAll();
        Task<ICollection<TObject>> GetAllAsync();
        TObject Get(Guid id);
        TObject Get(string id);
        Task<TObject> GetAsync(Guid id);
        Task<TObject> GetAsync(string id);
        TObject Find(Expression<Func<TObject, bool>> match);
        Task<TObject> FindAsync(Expression<Func<TObject, bool>> match);
        ICollection<TObject> FindAll(Expression<Func<TObject, bool>> match);
        Task<ICollection<TObject>> FindAllAsync(Expression<Func<TObject, bool>> match);
        TObject Add(TObject t);
        Task<TObject> AddAsync(TObject t);
        TObject Update(TObject updated, Guid key);
        Task<TObject> UpdateAsync(TObject updated, Guid key);
        int Delete(TObject t);
        Task<int> DeleteAsync(TObject t);
        int Count();
        Task<int> CountAsync();
    }
}
