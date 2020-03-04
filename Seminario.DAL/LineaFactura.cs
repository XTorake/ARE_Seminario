using System.Collections.Generic;
using Seminario.DAL.Repository;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;

namespace Seminario.DAL
{
    public class LineaFactura : ICrud<data.LineaFactura>
    {
        private Repository<data.LineaFactura> _repository = new Repository<data.LineaFactura>(new data.ARE_SeminarioEntities());

        public void Delete(data.LineaFactura t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.LineaFactura> GetAll()
        {
            return _repository.GetAll();
        }

        public data.LineaFactura GetOneById(int id)
        {
            return _repository.GetOneByID(id);
        }

        public void Insert(data.LineaFactura t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.LineaFactura t)
        {
            _repository.Updated(t);
            _repository.Commit();
        }
    }
}
