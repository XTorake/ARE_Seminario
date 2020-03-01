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
    public class Carrera : ICRUD<data.Carrera>
    {
        private Repository.Repository<data.Carrera> _repository = new Repository.Repository<data.Carrera>(new ARE_SeminarioEntities());

        public void Delete(data.Carrera t)
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

        public IEnumerable<data.Carrera> GetAll()
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

        public data.Carrera GetOneById(int id)
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

        public void Insert(data.Carrera t)
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

        public void Updated(data.Carrera t)
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
