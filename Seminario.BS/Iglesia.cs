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
    public class Iglesia : ent.Interfaces.ICRUD<ent.Objects.Iglesia>
    {
        public void Delete(ent.Objects.Iglesia t)
        {
            var _ent = Mapper.Map<ent.Objects.Iglesia, data.Iglesia>(t);
            new dal.Iglesia().Delete(_ent);
        }

        public IEnumerable<ent.Objects.Iglesia> GetAll()
        {
            var DetailsQuery = new dal.Iglesia().GetAll();
            var res = Mapper.Map<IEnumerable<data.Iglesia>, IEnumerable<ent.Objects.Iglesia>>(DetailsQuery);
            return res;
        }

        public ent.Objects.Iglesia GetOneById(int id)
        {
            var DetailsQuery = new dal.Iglesia().GetOneById(id);
            var res = Mapper.Map<data.Iglesia, ent.Objects.Iglesia>(DetailsQuery);
            return res;
        }

        public void Insert(ent.Objects.Iglesia t)
        {
            var _ent = Mapper.Map<ent.Objects.Iglesia, data.Iglesia>(t);
            new dal.Iglesia().Insert(_ent);
        }

        public void Updated(ent.Objects.Iglesia t)
        {
            var _ent = Mapper.Map<ent.Objects.Iglesia, data.Iglesia>(t);
            new dal.Iglesia().Updated(_ent);
        }
    }
}
