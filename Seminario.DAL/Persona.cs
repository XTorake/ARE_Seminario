using System.Collections.Generic;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class Persona : ICrud<data.Persona>
    {
        private Repository<data.Persona> _repository = new Repository<data.Persona>(new data.ARE_SeminarioEntities());

        public void Delete(data.Persona t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Persona> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Persona GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }

        public void Insert(data.Persona t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.Persona t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}
