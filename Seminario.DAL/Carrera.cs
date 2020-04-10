using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class Carrera : ICrud<data.Carrera>
    {
        private readonly Repository<data.Carrera> _repository = new Repository<data.Carrera>(new data.ARE_SeminarioEntities());

        public void Delete(data.Carrera t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Carrera> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Carrera GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }
        public data.Carrera GetOneById(string id)
        {
            return _repository.GetOneByID(id);
        }

        public data.Carrera GetOne(Expression<Func<data.Carrera, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Carrera t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.Carrera t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}
