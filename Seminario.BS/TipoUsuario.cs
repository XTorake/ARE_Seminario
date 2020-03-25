using System.Collections.Generic;
using AutoMapper;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;
using ent = Seminario.DO;
using dal = Seminario.DAL;

namespace Seminario.BS
{
    public class TipoUsuario : ICrud<DO.Objects.TipoUsuario>
    {
        public void Delete(DO.Objects.TipoUsuario t)
        {
            var ent = Mapper.Map<DO.Objects.TipoUsuario, data.TipoUsuario>(t);
            new dal.TipoUsuario().Delete(ent);
        }

        public IEnumerable<DO.Objects.TipoUsuario> GetAll()
        {
            var detailsQuery = new dal.TipoUsuario().GetAll();
            var res = Mapper.Map<IEnumerable<data.TipoUsuario>, IEnumerable<DO.Objects.TipoUsuario>>(detailsQuery);
            return res;
        }

        public DO.Objects.TipoUsuario GetOneById(int id)
        {
            var detailsQuery = new dal.TipoUsuario().GetOneById(id);
            var res = Mapper.Map<data.TipoUsuario, DO.Objects.TipoUsuario>(detailsQuery);
            return res;
        }
        public DO.Objects.TipoUsuario GetOneById(string id)
        {
            var detailsQuery = new dal.TipoUsuario().GetOneById(id);
            var res = Mapper.Map<data.TipoUsuario, DO.Objects.TipoUsuario>(detailsQuery);
            return res;
        }

        public void Insert(DO.Objects.TipoUsuario t)
        {
            var ent = Mapper.Map<DO.Objects.TipoUsuario, data.TipoUsuario>(t);
            new dal.TipoUsuario().Insert(ent);
        }

        public void Updated(DO.Objects.TipoUsuario t)
        {
            var ent = Mapper.Map<DO.Objects.TipoUsuario, data.TipoUsuario>(t);
            new dal.TipoUsuario().Updated(ent);
        }
    }
}
