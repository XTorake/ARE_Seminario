using System.Collections.Generic;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class Producto : ICrud<data.Producto>
    {
        private Repository<data.Producto> _repository = new Repository<data.Producto>(new data.ARE_SeminarioEntities());

        public void Delete(data.Producto t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Producto> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Producto GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }
        public data.Producto GetOneById(string id)
        {
            return _repository.GetOneByID(id);
        }

        public void Insert(data.Producto t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.Producto t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}
