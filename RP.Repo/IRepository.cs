using RP.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RP.Repo
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> Get();

        Task<List<T>> GetAsync();

        Task<T> GetEntityAsync(Guid id);

        Task<T> GetEntityAsync(Guid id, params Expression<Func<T, object>>[] includeProperties);

        T GetEntity(Guid id);

        T GetEntity(Guid id, params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}