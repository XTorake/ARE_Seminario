using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Seminario.DAL.EF;
using Seminario.DAL.EF;
using Seminario.DO.Interfaces;

namespace Seminario.DAL
{
    public class EncabezadoFactura : ICRUD<data.EncabezadoFactura>
    {
        private Repository.Repository<data.EncabezadoFactura> _repository = new Repository.Repository<data.EncabezadoFactura>(new ARE_SeminarioEntities());

        public void Delete(data.EncabezadoFactura t)
        {
            try
            {
                _repository.Delete(t);
                _repository.Commit();
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        public IEnumerable<data.EncabezadoFactura> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        public data.EncabezadoFactura GetOneById(int id)
        {
            try
            {
                return _repository.GetOneByID(id);
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        public void Insert(data.EncabezadoFactura t)
        {
            try
            {
                _repository.Insert(t);
                _repository.Commit();
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        public void Updated(data.EncabezadoFactura t)
        {
            try
            {
                _repository.Updated(t);
                _repository.Commit();
            }
            catch (Exception ee)
            {

                throw;
            }
        }
    }
}
