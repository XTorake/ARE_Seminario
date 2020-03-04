using System.Collections.Generic;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class CategoriaProducto : ICrud<data.CategoriaProducto>
    {
        private Repository<data.CategoriaProducto> _repository = new Repository<data.CategoriaProducto>(new data.ARE_SeminarioEntities());

        public void Delete(data.CategoriaProducto t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.CategoriaProducto> GetAll()
        {
            return _repository.GetAll();
        }

        public data.CategoriaProducto GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }

        public void Insert(data.CategoriaProducto t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.CategoriaProducto t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}
