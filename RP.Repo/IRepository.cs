﻿using RP.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RP.Repo
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Get();

        IQueryable<T> Get(Expression<Func<T, bool>> predicate);

        Task<T> Add(T entity);

        Task Update(T entity);

        Task<bool> Delete(Guid id);
    }
}