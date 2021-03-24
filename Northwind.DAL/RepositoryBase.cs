using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Core.Abstractions.Repositories;

namespace Northwind.DAL
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        protected readonly NorthwindContext Context;

        public RepositoryBase(NorthwindContext dbContext)
        {
            Context = dbContext;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);

        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public T Get(int id)
        {
            var entity = Context.Set<T>().Find(id);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            var entities = Context.Set<T>().ToArray();
            return entities;
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public bool Any(Func<T,bool> condition)
        {
            return Context.Set<T>().Any(condition);
        }

        public T GetSingle(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
