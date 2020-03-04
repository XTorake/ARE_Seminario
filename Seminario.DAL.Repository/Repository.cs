using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Seminario.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        public Repository(DbContext context)
        {
            _dbContext = context;
        }
        public IQueryable<T> AsQueryble()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.Set<T>().Add(entity);
            }
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public T GetOne(Expression<Func<T, bool>> predicado)
        {
            return _dbContext.Set<T>().Where(predicado).FirstOrDefault();
        }

        public T GetOneByID(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.Entry(entity).State = EntityState.Added;
            }
            else
            {
                _dbContext.Set<T>().Add(entity);
            }
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicado)
        {
            return _dbContext.Set<T>().Where(predicado);
        }

        public void Updated(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.Set<T>().Attach(entity);
            }
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
