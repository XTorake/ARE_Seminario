using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;
using ent = Seminario.DO;
using dal = Seminario.DAL;

namespace Seminario.BS
{
    public class LineaFactura : ICrud<DO.Objects.LineaFactura>
    {
        public void Delete(DO.Objects.LineaFactura t)
        {
            var ent = Mapper.Map<DO.Objects.LineaFactura, data.LineaFactura>(t);
            new dal.LineaFactura().Delete(ent);
        }

        public IEnumerable<DO.Objects.LineaFactura> GetAll()
        {
            var detailsQuery = new dal.LineaFactura().GetAll();
            var res = Mapper.Map<IEnumerable<data.LineaFactura>, IEnumerable<DO.Objects.LineaFactura>>(detailsQuery);
            return res;
        }

        public DO.Objects.LineaFactura GetOneById(int id)
        {
            var detailsQuery = new dal.LineaFactura().GetOneById(id);
            var res = Mapper.Map<data.LineaFactura, DO.Objects.LineaFactura>(detailsQuery);
            return res;
        }
        public DO.Objects.LineaFactura GetOneById(string id)
        {
            var detailsQuery = new dal.LineaFactura().GetOneById(id);
            var res = Mapper.Map<data.LineaFactura, DO.Objects.LineaFactura>(detailsQuery);
            return res;
        }

        public DO.Objects.LineaFactura GetOne(Expression<Func<DO.Objects.LineaFactura, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public void Insert(DO.Objects.LineaFactura t)
        {
            var ent = Mapper.Map<DO.Objects.LineaFactura, data.LineaFactura>(t);
            new dal.LineaFactura().Insert(ent);
        }

        public void Updated(DO.Objects.LineaFactura t)
        {
            var ent = Mapper.Map<DO.Objects.LineaFactura, data.LineaFactura>(t);
            new dal.LineaFactura().Updated(ent);
        }
    }
}
