using System.Collections.Generic;
using AutoMapper;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;
using ent = Seminario.DO;
using dal = Seminario.DAL;

namespace Seminario.BS
{
    public class EncabezadoFactura : ICrud<DO.Objects.EncabezadoFactura>
    {
        public void Delete(DO.Objects.EncabezadoFactura t)
        {
            var ent = Mapper.Map<DO.Objects.EncabezadoFactura, data.EncabezadoFactura>(t);
            new dal.EncabezadoFactura().Delete(ent);
        }

        public IEnumerable<DO.Objects.EncabezadoFactura> GetAll()
        {
            var detailsQuery = new dal.EncabezadoFactura().GetAll();
            var res = Mapper.Map<IEnumerable<data.EncabezadoFactura>, IEnumerable<DO.Objects.EncabezadoFactura>>(detailsQuery);
            return res;
        }

        public DO.Objects.EncabezadoFactura GetOneById(int id)
        {
            var detailsQuery = new dal.EncabezadoFactura().GetOneById(id);
            var res = Mapper.Map<data.EncabezadoFactura, DO.Objects.EncabezadoFactura>(detailsQuery);
            return res;
        }
        public DO.Objects.EncabezadoFactura GetOneById(string id)
        {
            var detailsQuery = new dal.EncabezadoFactura().GetOneById(id);
            var res = Mapper.Map<data.EncabezadoFactura, DO.Objects.EncabezadoFactura>(detailsQuery);
            return res;
        }
        public void Insert(DO.Objects.EncabezadoFactura t)
        {
            var ent = Mapper.Map<DO.Objects.EncabezadoFactura, data.EncabezadoFactura>(t);
            new dal.EncabezadoFactura().Insert(ent);
        }

        public void Updated(DO.Objects.EncabezadoFactura t)
        {
            var ent = Mapper.Map<DO.Objects.EncabezadoFactura, data.EncabezadoFactura>(t);
            new dal.EncabezadoFactura().Updated(ent);
        }
    }
}
