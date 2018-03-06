using Microsoft.EntityFrameworkCore;
using RP.Data;
using System;
using System.Collections.Generic;

namespace RP.Repo
{
    public class RepositoryFactory<TContext> : IRepositoryFactory<TContext>, IRepositoryFactory where TContext : DbContext
    {
        private readonly TContext context;
        private Dictionary<Type, object> repositories;

        public RepositoryFactory(TContext context)
        {
            Console.WriteLine($"+ {GetType().Name} was created");
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TContext Context => context;

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            Console.WriteLine($"Repository for {typeof(TEntity)} obtained");
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

        public void Dispose()
        {
            Console.WriteLine($"- {GetType().Name} was disposed!");
            context?.Dispose();
        }
    }
}