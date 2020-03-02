using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using data = Seminario.DAL.EF;
using ent = Seminario.DO;
using dal = Seminario.DAL;
using Seminario.DO.Objects;

namespace Seminario.BS
{
    public class TipoUsuario : ent.Interfaces.ICRUD<ent.Objects.TipoUsuario>
    {
        public void Delete(ent.Objects.TipoUsuario t)
        {
            var _ent = Mapper.Map<ent.Objects.TipoUsuario, data.TipoUsuario>(t);
            new dal.TipoUsuario().Delete(_ent);
        }

        public IEnumerable<ent.Objects.TipoUsuario> GetAll()
        {
            var DetailsQuery = new dal.TipoUsuario().GetAll();
            var res = Mapper.Map<IEnumerable<data.TipoUsuario>, IEnumerable<ent.Objects.TipoUsuario>>(DetailsQuery);
            return res;
        }

        public ent.Objects.TipoUsuario GetOneById(int id)
        {
            var DetailsQuery = new dal.TipoUsuario().GetOneById(id);
            var res = Mapper.Map<data.TipoUsuario, ent.Objects.TipoUsuario>(DetailsQuery);
            return res;
        }

        public void Insert(ent.Objects.TipoUsuario t)
        {
            var _ent = Mapper.Map<ent.Objects.TipoUsuario, data.TipoUsuario>(t);
            new dal.TipoUsuario().Insert(_ent);
        }

        public void Updated(ent.Objects.TipoUsuario t)
        {
            var _ent = Mapper.Map<ent.Objects.TipoUsuario, data.TipoUsuario>(t);
            new dal.TipoUsuario().Updated(_ent);
        }
    }
}
