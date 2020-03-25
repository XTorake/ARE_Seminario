using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Seminario.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AsQueryble();
        IEnumerable<T> GetAll();
        IEnumerable<T> Search(Expression<Func<T, bool>> predicado);
        T GetOne(Expression<Func<T, bool>> predicado);
        T GetOneByID(int id);
        T GetOneByID(string id);
        void Insert(T entity);
        void Updated(T entity);
        void Delete(T entity);
        void Commit();
    }
}
