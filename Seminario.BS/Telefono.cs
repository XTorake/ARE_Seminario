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
    public class Telefono : ent.Interfaces.ICRUD<ent.Objects.Telefono>
    {
        public void Delete(ent.Objects.Telefono t)
        {
            var _ent = Mapper.Map<ent.Objects.Telefono, data.Telefono>(t);
            new dal.Telefono().Delete(_ent);
        }

        public IEnumerable<ent.Objects.Telefono> GetAll()
        {
            var DetailsQuery = new dal.Telefono().GetAll();
            var res = Mapper.Map<IEnumerable<data.Telefono>, IEnumerable<ent.Objects.Telefono>>(DetailsQuery);
            return res;
        }

        public ent.Objects.Telefono GetOneById(int id)
        {
            var DetailsQuery = new dal.Telefono().GetOneById(id);
            var res = Mapper.Map<data.Telefono, ent.Objects.Telefono>(DetailsQuery);
            return res;
        }

        public void Insert(ent.Objects.Telefono t)
        {
            var _ent = Mapper.Map<ent.Objects.Telefono, data.Telefono>(t);
            new dal.Telefono().Insert(_ent);
        }

        public void Updated(ent.Objects.Telefono t)
        {
            var _ent = Mapper.Map<ent.Objects.Telefono, data.Telefono>(t);
            new dal.Telefono().Updated(_ent);
        }
    }
}
