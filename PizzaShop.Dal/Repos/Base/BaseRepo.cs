using System;
using System.Collections.Generic;
using System.Linq;
using PizzaShop.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Dal.Data;

namespace PizzaShop.Dal.Repos.Base
{
    public abstract class BaseRepo<T> : IRepo<T> where T : BaseEntity, new()
    {
        private readonly bool _disposeContext;
        public ApplicationDbContext Context { get; }

        public DbSet<T> Table { get; }

        protected BaseRepo(ApplicationDbContext context)
        {
            Context = context;
            Table = Context.Set<T>();
            _disposeContext = false;
        }

        protected BaseRepo(DbContextOptions<ApplicationDbContext> options)
        {
            this.options = options;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred updating the database", ex);
            }
        }

        private bool _isDisposed;
        private DbContextOptions<ApplicationDbContext> options;

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }
            if (disposing)
            {
                if (_disposeContext)
                {
                    Context.Dispose();
                }
            }
            _isDisposed = true;
        }

        ~BaseRepo()
        {
            Dispose(false);
        }

        public virtual Task<int> AddAsync(T entity, bool persist = true)
        {
            Table.AddAsync(entity);
            return Context.SaveChangesAsync();
        }

        public virtual Task<int> DeleteAsync(T entity, bool persist = true)
        {
            Table.Remove(entity);
            return Context.SaveChangesAsync();
        }

        public abstract Task<int> UpdateAsync(T entity, bool persist = true);
        public abstract Task<T> FindAsync(int? id);
        public abstract Task<IEnumerable<T>> GetAllAsync();
    }
}
