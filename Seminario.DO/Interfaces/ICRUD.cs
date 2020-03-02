using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.DO.Interfaces
{
    public interface ICRUD<T>
    {
        void Insert(T t);
        void Updated(T t);
        void Delete(T t);
        IEnumerable<T> GetAll();
        T GetOneById(int id);
    }
}
