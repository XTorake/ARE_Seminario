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
    public class Curso : ICRUD<data.Curso>
    {
        private Repository.Repository<data.Curso> _repository = new Repository.Repository<data.Curso>(new ARE_SeminarioEntities());

        public void Delete(data.Curso t)
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

        public IEnumerable<data.Curso> GetAll()
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

        public data.Curso GetOneById(int id)
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

        public void Insert(data.Curso t)
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

        public void Updated(data.Curso t)
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
