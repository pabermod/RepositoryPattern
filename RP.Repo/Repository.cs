using Microsoft.EntityFrameworkCore;
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
        protected readonly DbContext context;
        protected readonly DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        public async Task<Guid> Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.Id = Guid.NewGuid();
            var entry = await dbSet.AddAsync(entity);
            await SaveAsync();
            return entry.Entity.Id;
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

        public async Task Delete(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }
            T existing = dbSet.Find(id);
            if (existing != null)
            {
                dbSet.Remove(existing);
                await SaveAsync();
            }
        }

        public IQueryable<T> Get()
        {
            return dbSet.AsNoTracking();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).AsQueryable();
        }

        public Task<T> GetEntity(Guid id)
        {
            return dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<T> GetEntity(Guid id, params Expression<Func<T, object>>[] includeProperties)
        {
            IEnumerable<string> properties = GetProperties(includeProperties);

            IQueryable<T> queryable = dbSet;

            foreach (var property in includeProperties)
            {
                queryable = dbSet.Include(property);
            }

            return queryable.FirstOrDefaultAsync(x => x.Id == id);
        }

        private static IEnumerable<string> GetProperties(Expression<Func<T, object>>[] includeProperties)
        {
            List<string> includelist = new List<string>();

            foreach (var item in includeProperties)
            {
                MemberExpression body = item.Body as MemberExpression;
                if (body == null)
                    throw new ArgumentException("The body must be a member expression");

                includelist.Add(body.Member.Name);
            }
            return includelist.AsEnumerable();
        }

        private async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}