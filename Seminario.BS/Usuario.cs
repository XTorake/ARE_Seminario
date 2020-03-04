using System.Collections.Generic;
using AutoMapper;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;
using ent = Seminario.DO;
using dal = Seminario.DAL;

namespace Seminario.BS
{
    public class Usuario : ICrud<DO.Objects.Usuario>
    {
        public void Delete(DO.Objects.Usuario t)
        {
            var ent = Mapper.Map<DO.Objects.Usuario, data.Usuario>(t);
            new dal.Usuario().Delete(ent);
        }

        public IEnumerable<DO.Objects.Usuario> GetAll()
        {
            var detailsQuery = new dal.Usuario().GetAll();
            var res = Mapper.Map<IEnumerable<data.Usuario>, IEnumerable<DO.Objects.Usuario>>(detailsQuery);
            return res;
        }

        public DO.Objects.Usuario GetOneById(int id)
        {
            var detailsQuery = new dal.Usuario().GetOneById(id);
            var res = Mapper.Map<data.Usuario, DO.Objects.Usuario>(detailsQuery);
            return res;
        }

        public void Insert(DO.Objects.Usuario t)
        {
            var ent = Mapper.Map<DO.Objects.Usuario, data.Usuario>(t);
            new dal.Usuario().Insert(ent);
        }

        public void Updated(DO.Objects.Usuario t)
        {
            var ent = Mapper.Map<DO.Objects.Usuario, data.Usuario>(t);
            new dal.Usuario().Updated(ent);
        }
    }
}
