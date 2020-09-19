using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Tresa.Services.Contracts
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate, 
                            string[] navigationPropertyPaths, 
                            List<Expression<Func<T,object>>> keySelectors, 
                            string[] selectors);
        T Add(T entity);
        T Update(T entity);
        T Remove(T entity);
        int SaveChanges();
    }
}
