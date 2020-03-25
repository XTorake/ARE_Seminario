using System.Collections.Generic;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class EncabezadoFactura : ICrud<data.EncabezadoFactura>
    {
        private Repository<data.EncabezadoFactura> _repository = new Repository<data.EncabezadoFactura>(new data.ARE_SeminarioEntities());

        public void Delete(data.EncabezadoFactura t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.EncabezadoFactura> GetAll()
        {
            return _repository.GetAll();
        }

        public data.EncabezadoFactura GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }
        public data.EncabezadoFactura GetOneById(string id)
        {
            return _repository.GetOneByID(id);
        }
        public void Insert(data.EncabezadoFactura t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.EncabezadoFactura t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}
