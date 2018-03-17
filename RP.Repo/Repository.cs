using Microsoft.EntityFrameworkCore;
using RP.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RP.Repo
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext context;
        protected readonly DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        public IQueryable<T> Get()
        {
            return dbSet;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).AsQueryable();
        }

        public async Task<T> Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.Id = Guid.NewGuid();
            var entry = await dbSet.AddAsync(entity);
            await SaveAsync();
            return entry.Entity;
        }

        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            context.Entry(entity).State = EntityState.Modified;
            dbSet.Attach(entity);
            await SaveAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("id");
            }
            T existing = dbSet.Find(id);
            if (existing != null)
            {
                dbSet.Remove(existing);
                await SaveAsync();
                return true;
            }
            return false;
        }

        private async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}