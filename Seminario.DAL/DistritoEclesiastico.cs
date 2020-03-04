using System.Collections.Generic;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class DistritoEclesiastico : ICrud<data.DistritoEclesiastico>
    {
        private Repository<data.DistritoEclesiastico> _repository = new Repository<data.DistritoEclesiastico>(new data.ARE_SeminarioEntities());

        public void Delete(data.DistritoEclesiastico t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.DistritoEclesiastico> GetAll()
        {
            return _repository.GetAll();
        }

        public data.DistritoEclesiastico GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }

        public void Insert(data.DistritoEclesiastico t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.DistritoEclesiastico t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}
