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
    public class DistritoEclesiastico : ICrud<DO.Objects.DistritoEclesiastico>
    {
        public void Delete(DO.Objects.DistritoEclesiastico t)
        {
            var ent = Mapper.Map<DO.Objects.DistritoEclesiastico, data.DistritoEclesiastico>(t);
            new dal.DistritoEclesiastico().Delete(ent);
        }

        public IEnumerable<DO.Objects.DistritoEclesiastico> GetAll()
        {
            var detailsQuery = new dal.DistritoEclesiastico().GetAll();
            var res = Mapper.Map<IEnumerable<data.DistritoEclesiastico>, IEnumerable<DO.Objects.DistritoEclesiastico>>(detailsQuery);
            return res;
        }

        public DO.Objects.DistritoEclesiastico GetOneById(int id)
        {
            var detailsQuery = new dal.DistritoEclesiastico().GetOneById(id);
            var res = Mapper.Map<data.DistritoEclesiastico, DO.Objects.DistritoEclesiastico>(detailsQuery);
            return res;
        }
        public DO.Objects.DistritoEclesiastico GetOneById(string id)
        {
            var detailsQuery = new dal.DistritoEclesiastico().GetOneById(id);
            var res = Mapper.Map<data.DistritoEclesiastico, DO.Objects.DistritoEclesiastico>(detailsQuery);
            return res;
        }

        public DO.Objects.DistritoEclesiastico GetOne(Expression<Func<DO.Objects.DistritoEclesiastico, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public void Insert(DO.Objects.DistritoEclesiastico t)
        {
            var ent = Mapper.Map<DO.Objects.DistritoEclesiastico, data.DistritoEclesiastico>(t);
            new dal.DistritoEclesiastico().Insert(ent);
        }

        public void Updated(DO.Objects.DistritoEclesiastico t)
        {
            var ent = Mapper.Map<DO.Objects.DistritoEclesiastico, data.DistritoEclesiastico>(t);
            new dal.DistritoEclesiastico().Updated(ent);
        }
    }
}
