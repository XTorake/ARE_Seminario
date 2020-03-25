using System.Collections.Generic;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class Telefono : ICrud<data.Telefono>
    {
        private Repository<data.Telefono> _repository = new Repository<data.Telefono>(new data.ARE_SeminarioEntities());

        public void Delete(data.Telefono t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Telefono> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Telefono GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }
        public data.Telefono GetOneById(string id)
        {
            return _repository.GetOneByID(id);
        }
        public void Insert(data.Telefono t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.Telefono t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}

