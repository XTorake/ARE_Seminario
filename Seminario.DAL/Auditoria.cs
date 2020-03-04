using System.Collections.Generic;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class Auditoria : ICrud<data.Auditoria>
    {
        private readonly Repository<data.Auditoria> _repository = new Repository<data.Auditoria>(new data.ARE_SeminarioEntities());

        public void Delete(data.Auditoria t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Auditoria> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Auditoria GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }

        public void Insert(data.Auditoria t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.Auditoria t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}
