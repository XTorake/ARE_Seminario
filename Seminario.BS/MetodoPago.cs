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
    public class MetodoPago : ent.Interfaces.ICRUD<ent.Objects.MetodoPago>
    {
        public void Delete(ent.Objects.MetodoPago t)
        {
            var _ent = Mapper.Map<ent.Objects.MetodoPago, data.MetodoPago>(t);
            new dal.MetodoPago().Delete(_ent);
        }

        public IEnumerable<ent.Objects.MetodoPago> GetAll()
        {
            var DetailsQuery = new dal.MetodoPago().GetAll();
            var res = Mapper.Map<IEnumerable<data.MetodoPago>, IEnumerable<ent.Objects.MetodoPago>>(DetailsQuery);
            return res;
        }

        public ent.Objects.MetodoPago GetOneById(int id)
        {
            var DetailsQuery = new dal.MetodoPago().GetOneById(id);
            var res = Mapper.Map<data.MetodoPago, ent.Objects.MetodoPago>(DetailsQuery);
            return res;
        }

        public void Insert(ent.Objects.MetodoPago t)
        {
            var _ent = Mapper.Map<ent.Objects.MetodoPago, data.MetodoPago>(t);
            new dal.MetodoPago().Insert(_ent);
        }

        public void Updated(ent.Objects.MetodoPago t)
        {
            var _ent = Mapper.Map<ent.Objects.MetodoPago, data.MetodoPago>(t);
            new dal.MetodoPago().Updated(_ent);
        }
    }
}
