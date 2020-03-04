using System.Collections.Generic;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class Iglesia : ICrud<data.Iglesia>
    {
        private readonly Repository<data.Iglesia> _repository = new Repository<data.Iglesia>(new data.ARE_SeminarioEntities());

        public void Delete(data.Iglesia t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Iglesia> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Iglesia GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }

        public void Insert(data.Iglesia t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.Iglesia t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}
