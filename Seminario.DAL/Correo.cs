using System.Collections.Generic;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class Correo : ICrud<data.Correo>
    {
        private Repository<data.Correo> _repository = new Repository<data.Correo>(new data.ARE_SeminarioEntities());

        public void Delete(data.Correo t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Correo> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Correo GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }

        public void Insert(data.Correo t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.Correo t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}
