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
    public class Correo : ent.Interfaces.ICRUD<ent.Objects.Correo>
    {
        public void Delete(ent.Objects.Correo t)
        {
            var _ent = Mapper.Map<ent.Objects.Correo, data.Correo>(t);
            new dal.Correo().Delete(_ent);
        }

        public IEnumerable<ent.Objects.Correo> GetAll()
        {
            var DetailsQuery = new dal.Correo().GetAll();
            var res = Mapper.Map<IEnumerable<data.Correo>, IEnumerable<ent.Objects.Correo>>(DetailsQuery);
            return res;
        }

        public ent.Objects.Correo GetOneById(int id)
        {
            var DetailsQuery = new dal.Correo().GetOneById(id);
            var res = Mapper.Map<data.Correo, ent.Objects.Correo>(DetailsQuery);
            return res;
        }

        public void Insert(ent.Objects.Correo t)
        {
            var _ent = Mapper.Map<ent.Objects.Correo, data.Correo>(t);
            new dal.Correo().Insert(_ent);
        }

        public void Updated(ent.Objects.Correo t)
        {
            var _ent = Mapper.Map<ent.Objects.Correo, data.Correo>(t);
            new dal.Correo().Updated(_ent);
        }
    }
}
