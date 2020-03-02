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
    public class CategoriaProducto : ICRUD<data.CategoriaProducto>
    {
        private Repository.Repository<data.CategoriaProducto> _repository = new Repository.Repository<data.CategoriaProducto>(new ARE_SeminarioEntities());

        public void Delete(data.CategoriaProducto t)
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

        public IEnumerable<data.CategoriaProducto> GetAll()
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

        public data.CategoriaProducto GetOneById(int id)
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

        public void Insert(data.CategoriaProducto t)
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

        public void Updated(data.CategoriaProducto t)
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
