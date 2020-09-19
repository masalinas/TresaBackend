using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

namespace Tresa.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TresaDbContext context;

        public DbSet<T> DbSet { get; }

        public Repository(TresaDbContext context)
        {
            this.context = context;

            DbSet = this.context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {            
            return DbSet.ToList();
        }

        public T Get(long id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public T Add(T entity)
        {
            DbSet.Add(entity);

            return entity;
        }

        public T Update(T entity)
        {
            DbSet.Update(entity);

            return entity;
        }

        public T Remove(T entity)
        {
            DbSet.Remove(entity);

            return entity;
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}