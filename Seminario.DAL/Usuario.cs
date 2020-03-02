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
    public class Usuario : ICRUD<data.Usuario>
    {
        private Repository.Repository<data.Usuario> _repository = new Repository.Repository<data.Usuario>(new ARE_SeminarioEntities());

        public void Delete(data.Usuario t)
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

        public IEnumerable<data.Usuario> GetAll()
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

        public data.Usuario GetOneById(int id)
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

        public void Insert(data.Usuario t)
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

        public void Updated(data.Usuario t)
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
