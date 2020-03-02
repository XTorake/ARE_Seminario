using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext dbContext;
        public Repository(DbContext context)
        {
            dbContext = context;
        }
        public IQueryable<T> AsQueryble()
        {
            return dbContext.Set<T>().AsQueryable();
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (dbContext.Entry<T>(entity).State == EntityState.Detached)
            {
                dbContext.Set<T>().Add(entity);
            }
            dbContext.Entry<T>(entity).State = EntityState.Deleted;
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public T GetOne(Expression<Func<T, bool>> predicado)
        {
            return dbContext.Set<T>().Where(predicado).FirstOrDefault();
        }

        public T GetOneByID(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            if (dbContext.Entry<T>(entity).State == EntityState.Detached)
            {
                dbContext.Entry<T>(entity).State = EntityState.Added;
            }
            else
            {
                dbContext.Set<T>().Add(entity);
            }
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicado)
        {
            return dbContext.Set<T>().Where(predicado);
        }

        public void Updated(T entity)
        {
            if (dbContext.Entry<T>(entity).State == EntityState.Detached)
            {
                dbContext.Set<T>().Attach(entity);
            }
            dbContext.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}
