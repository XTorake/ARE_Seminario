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
    public class LineaFactura : ent.Interfaces.ICRUD<ent.Objects.LineaFactura>
    {
        public void Delete(ent.Objects.LineaFactura t)
        {
            var _ent = Mapper.Map<ent.Objects.LineaFactura, data.LineaFactura>(t);
            new dal.LineaFactura().Delete(_ent);
        }

        public IEnumerable<ent.Objects.LineaFactura> GetAll()
        {
            var DetailsQuery = new dal.LineaFactura().GetAll();
            var res = Mapper.Map<IEnumerable<data.LineaFactura>, IEnumerable<ent.Objects.LineaFactura>>(DetailsQuery);
            return res;
        }

        public ent.Objects.LineaFactura GetOneById(int id)
        {
            var DetailsQuery = new dal.LineaFactura().GetOneById(id);
            var res = Mapper.Map<data.LineaFactura, ent.Objects.LineaFactura>(DetailsQuery);
            return res;
        }

        public void Insert(ent.Objects.LineaFactura t)
        {
            var _ent = Mapper.Map<ent.Objects.LineaFactura, data.LineaFactura>(t);
            new dal.LineaFactura().Insert(_ent);
        }

        public void Updated(ent.Objects.LineaFactura t)
        {
            var _ent = Mapper.Map<ent.Objects.LineaFactura, data.LineaFactura>(t);
            new dal.LineaFactura().Updated(_ent);
        }
    }
}
