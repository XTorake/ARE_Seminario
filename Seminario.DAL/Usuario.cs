using System.Collections.Generic;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class Usuario : ICrud<data.Usuario>
    {
        private readonly Repository<data.Usuario> _repository = new Repository<data.Usuario>(new data.ARE_SeminarioEntities());

        public void Delete(data.Usuario t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Usuario> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Usuario GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }
        public data.Usuario GetOneById(string id)
        {
            return _repository.GetOneByID(id);
        }
        public void Insert(data.Usuario t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.Usuario t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}
