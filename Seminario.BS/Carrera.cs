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
    public class Carrera : ICrud<DO.Objects.Carrera>
    {
        public void Delete(DO.Objects.Carrera t)
        {
            var ent = Mapper.Map<DO.Objects.Carrera, data.Carrera>(t);
            new dal.Carrera().Delete(ent);
        }

        public IEnumerable<DO.Objects.Carrera> GetAll()
        {
            var detailsQuery = new dal.Carrera().GetAll();
            var res = Mapper.Map<IEnumerable<data.Carrera>, IEnumerable<DO.Objects.Carrera>>(detailsQuery);
            return res;
        }

        public DO.Objects.Carrera GetOneById(int id)
        {
            var detailsQuery = new dal.Carrera().GetOneById(id);
            var res = Mapper.Map<data.Carrera, DO.Objects.Carrera>(detailsQuery);
            return res;
        }
        public DO.Objects.Carrera GetOneById(string id)
        {
            var detailsQuery = new dal.Carrera().GetOneById(id);
            var res = Mapper.Map<data.Carrera, DO.Objects.Carrera>(detailsQuery);
            return res;
        }

        public DO.Objects.Carrera GetOne(Expression<Func<DO.Objects.Carrera, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public void Insert(DO.Objects.Carrera t)
        {
            var ent = Mapper.Map<DO.Objects.Carrera, data.Carrera>(t);
            new dal.Carrera().Insert(ent);
        }

        public void Updated(DO.Objects.Carrera t)
        {
            var ent = Mapper.Map<DO.Objects.Carrera, data.Carrera>(t);
            new dal.Carrera().Updated(ent);
        }
    }
}
