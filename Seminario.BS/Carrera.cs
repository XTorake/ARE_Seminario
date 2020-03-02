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
    public class Carrera : ent.Interfaces.ICRUD<ent.Objects.Carrera>
    {
        public void Delete(ent.Objects.Carrera t)
        {
            var _ent = Mapper.Map<ent.Objects.Carrera, data.Carrera>(t);
            new dal.Carrera().Delete(_ent);
        }

        public IEnumerable<ent.Objects.Carrera> GetAll()
        {
            var DetailsQuery = new dal.Carrera().GetAll();
            var res = Mapper.Map<IEnumerable<data.Carrera>, IEnumerable<ent.Objects.Carrera>>(DetailsQuery);
            return res;
        }

        public ent.Objects.Carrera GetOneById(int id)
        {
            var DetailsQuery = new dal.Carrera().GetOneById(id);
            var res = Mapper.Map<data.Carrera, ent.Objects.Carrera>(DetailsQuery);
            return res;
        }

        public void Insert(ent.Objects.Carrera t)
        {
            var _ent = Mapper.Map<ent.Objects.Carrera, data.Carrera>(t);
            new dal.Carrera().Insert(_ent);
        }

        public void Updated(ent.Objects.Carrera t)
        {
            var _ent = Mapper.Map<ent.Objects.Carrera, data.Carrera>(t);
            new dal.Carrera().Updated(_ent);
        }
    }
}
