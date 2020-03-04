using System.Collections.Generic;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class CarreraxCurso : ICrud<data.CarreraxCurso>
    {
        private Repository<data.CarreraxCurso> _repository = new Repository<data.CarreraxCurso>(new data.ARE_SeminarioEntities());

        public void Delete(data.CarreraxCurso t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.CarreraxCurso> GetAll()
        {
            return _repository.GetAll();
        }

        public data.CarreraxCurso GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }

        public void Insert(data.CarreraxCurso t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.CarreraxCurso t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}
