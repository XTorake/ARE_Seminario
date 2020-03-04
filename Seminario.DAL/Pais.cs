using System.Collections.Generic;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class Pais : ICrud<data.Pai>
    {
        private Repository<data.Pai> _repository = new Repository<data.Pai>(new data.ARE_SeminarioEntities());

        public void Delete(data.Pai t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Pai> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Pai GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }

        public void Insert(data.Pai t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.Pai t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}
