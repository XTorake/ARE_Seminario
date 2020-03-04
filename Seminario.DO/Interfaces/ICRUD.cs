using System.Collections.Generic;

namespace Seminario.DO.Interfaces
{
    public interface ICrud<T>
    {
        void Insert(T t);
        void Updated(T t);
        void Delete(T t);
        IEnumerable<T> GetAll();
        T GetOneById(int id);
    }
}
