using System.Collections.Generic;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class Curso : ICrud<data.Curso>
    {
        private Repository<data.Curso> _repository = new Repository<data.Curso>(new data.ARE_SeminarioEntities());

        public void Delete(data.Curso t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Curso> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Curso GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }
        public data.Curso GetOneById(string id)
        {
            return _repository.GetOneByID(id);
        }
        public void Insert(data.Curso t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.Curso t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}
