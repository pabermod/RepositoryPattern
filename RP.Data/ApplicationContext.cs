using Microsoft.EntityFrameworkCore;
using RP.Data.Mappings;
using System;
using System.Linq;

namespace RP.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CustomerMap(modelBuilder.Entity<Customer>());
            new AddressMap(modelBuilder.Entity<Address>());
        }

        public override int SaveChanges()
        {
            DateTime saveTime = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added))
            {
                entry.Property("AddedDate").CurrentValue = saveTime;
            }

            foreach (var entry in ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified))
            {
                entry.Property("ModifiedDate").CurrentValue = saveTime;
            }
            return base.SaveChanges();
        }
    }
}