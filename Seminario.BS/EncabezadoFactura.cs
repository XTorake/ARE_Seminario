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
    public class EncabezadoFactura : ent.Interfaces.ICRUD<ent.Objects.EncabezadoFactura>
    {
        public void Delete(ent.Objects.EncabezadoFactura t)
        {
            var _ent = Mapper.Map<ent.Objects.EncabezadoFactura, data.EncabezadoFactura>(t);
            new dal.EncabezadoFactura().Delete(_ent);
        }

        public IEnumerable<ent.Objects.EncabezadoFactura> GetAll()
        {
            var DetailsQuery = new dal.EncabezadoFactura().GetAll();
            var res = Mapper.Map<IEnumerable<data.EncabezadoFactura>, IEnumerable<ent.Objects.EncabezadoFactura>>(DetailsQuery);
            return res;
        }

        public ent.Objects.EncabezadoFactura GetOneById(int id)
        {
            var DetailsQuery = new dal.EncabezadoFactura().GetOneById(id);
            var res = Mapper.Map<data.EncabezadoFactura, ent.Objects.EncabezadoFactura>(DetailsQuery);
            return res;
        }

        public void Insert(ent.Objects.EncabezadoFactura t)
        {
            var _ent = Mapper.Map<ent.Objects.EncabezadoFactura, data.EncabezadoFactura>(t);
            new dal.EncabezadoFactura().Insert(_ent);
        }

        public void Updated(ent.Objects.EncabezadoFactura t)
        {
            var _ent = Mapper.Map<ent.Objects.EncabezadoFactura, data.EncabezadoFactura>(t);
            new dal.EncabezadoFactura().Updated(_ent);
        }
    }
}
