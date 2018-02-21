using Microsoft.EntityFrameworkCore;
using RP.Data;
using System;
using System.Collections.Generic;

namespace RP.Repo
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext>, IUnitOfWork where TContext : DbContext
    {
        private readonly TContext context;
        private Dictionary<Type, object> repositories;

        public UnitOfWork(TContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TContext Context => context;

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories.Add(type, new Repository<TEntity>(context));
            }
            return (IRepository<TEntity>)repositories[type];
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}