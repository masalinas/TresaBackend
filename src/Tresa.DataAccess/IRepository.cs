using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

namespace Tresa.DataAccess
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> DbSet { get; }

        IEnumerable<T> GetAll();

        T Get(long id);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        T Add(T entity);

        T Update(T entity);

        T Remove(T entity);

        int SaveChanges();
    }
}