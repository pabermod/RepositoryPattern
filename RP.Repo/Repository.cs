﻿using Microsoft.EntityFrameworkCore;
using RP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RP.Repo
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            dbContext = context;
            dbSet = dbContext.Set<T>();
        }

        public T GetEntity(Guid id)
        {
            return dbSet.Find(id);
        }

        public Task<T> GetEntityAsync(Guid id)
        {
            return dbSet.FindAsync(id);
        }

        public IEnumerable<T> Get()
        {
            return dbSet.AsEnumerable();
        }

        public Task<List<T>> GetAsync()
        {
            return dbSet.ToListAsync();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).AsEnumerable();
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            dbSet.Add(entity);
        }

        public Task AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            return dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            dbContext.Entry(entity).State = EntityState.Modified;
            dbSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            T existing = dbSet.Find(entity.Id);
            if (existing != null)
            {
                dbSet.Remove(existing);
            }
        }
    }
}