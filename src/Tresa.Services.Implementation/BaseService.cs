using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Tresa.DataAccess;
using Tresa.Services.Contracts;

namespace Tresa.Services.Implementation
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly IRepository<T> repository;

        public BaseService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<T> GetAll()
        {
            return repository.GetAll().ToList<T>();
        }

        public T Get(long id)
        {
            return repository.Get(id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate, 
                                   string[] navigationPropertyPaths, 
                                   List<Expression<Func<T,object>>> keySelectors, 
                                   string[] selectors)
        {
            IQueryable<T> query = repository.DbSet;

            foreach (var navigationPropertyPath in navigationPropertyPaths)
            {
                query = query.Include<T>(navigationPropertyPath);
            }

            foreach (var keySelector in keySelectors)
            {
                query = query.OrderBy<T, object>(keySelector);
            }

            //query = query.Select()

            query = query.Where<T>(predicate);

            return query.ToList();
        }

        public T Add(T entity)
        {
            return repository.Add(entity);
        }

        public T Update(T entity)
        {
            return repository.Update(entity);
        }

        public T Remove(T entity)
        {
            return repository.Remove(entity);
        }

        public int SaveChanges()
        {
            return repository.SaveChanges();
        }
    }
}
