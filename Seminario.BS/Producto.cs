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
    public class Producto : ICrud<DO.Objects.Producto>
    {
        public void Delete(DO.Objects.Producto t)
        {
            var ent = Mapper.Map<DO.Objects.Producto, data.Producto>(t);
            new dal.Producto().Delete(ent);
        }

        public IEnumerable<DO.Objects.Producto> GetAll()
        {
            var detailsQuery = new dal.Producto().GetAll();
            var res = Mapper.Map<IEnumerable<data.Producto>, IEnumerable<DO.Objects.Producto>>(detailsQuery);
            return res;
        }

        public DO.Objects.Producto GetOneById(int id)
        {
            var detailsQuery = new dal.Producto().GetOneById(id);
            var res = Mapper.Map<data.Producto, DO.Objects.Producto>(detailsQuery);
            return res;
        }
        public DO.Objects.Producto GetOneById(string id)
        {
            var detailsQuery = new dal.Producto().GetOneById(id);
            var res = Mapper.Map<data.Producto, DO.Objects.Producto>(detailsQuery);
            return res;
        }

        public DO.Objects.Producto GetOne(Expression<Func<DO.Objects.Producto, bool>> predicado)
        {
            throw new NotImplementedException();
        }


        public void Insert(DO.Objects.Producto t)
        {
            var ent = Mapper.Map<DO.Objects.Producto, data.Producto>(t);
            new dal.Producto().Insert(ent);
        }

        public void Updated(DO.Objects.Producto t)
        {
            var ent = Mapper.Map<DO.Objects.Producto, data.Producto>(t);
            new dal.Producto().Updated(ent);
        }
    }
}
