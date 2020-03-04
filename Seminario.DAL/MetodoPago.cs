using System.Collections.Generic;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class MetodoPago : ICrud<data.MetodoPago>
    {
        private Repository<data.MetodoPago> _repository = new Repository<data.MetodoPago>(new data.ARE_SeminarioEntities());

        public void Delete(data.MetodoPago t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.MetodoPago> GetAll()
        {
            return _repository.GetAll();
        }

        public data.MetodoPago GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }

        public void Insert(data.MetodoPago t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.MetodoPago t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}
