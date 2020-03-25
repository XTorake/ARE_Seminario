using System.Collections.Generic;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class TipoUsuario : ICrud<data.TipoUsuario>
    {
        private readonly Repository<data.TipoUsuario> _repository = new Repository<data.TipoUsuario>(new data.ARE_SeminarioEntities());

        public void Delete(data.TipoUsuario t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.TipoUsuario> GetAll()
        {
            return _repository.GetAll();
        }

        public data.TipoUsuario GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }
        public data.TipoUsuario GetOneById(string id)
        {
            return _repository.GetOneByID(id);
        }
        public void Insert(data.TipoUsuario t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.TipoUsuario t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}
