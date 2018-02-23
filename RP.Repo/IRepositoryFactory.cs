using Microsoft.EntityFrameworkCore;
using RP.Data;
using System;

namespace RP.Repo
{
    public interface IRepositoryFactory : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
    }

    public interface IRepositoryFactory<TContext> : IRepositoryFactory where TContext : DbContext
    {
        TContext Context { get; }
    }
}