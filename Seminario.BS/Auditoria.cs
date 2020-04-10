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
    public class Auditoria : ICrud<DO.Objects.Auditoria>
    {
        public void Delete(DO.Objects.Auditoria t)
        {
            var ent = Mapper.Map<DO.Objects.Auditoria, data.Auditoria>(t);
            new dal.Auditoria().Delete(ent);
        }

        public IEnumerable<DO.Objects.Auditoria> GetAll()
        {
            var detailsQuery = new dal.Auditoria().GetAll();
            var res = Mapper.Map<IEnumerable<data.Auditoria>, IEnumerable<DO.Objects.Auditoria>>(detailsQuery);
            return res;
        }

        public DO.Objects.Auditoria GetOneById(int id)
        {
            var detailsQuery = new dal.Auditoria().GetOneById(id);
            var res = Mapper.Map<data.Auditoria, DO.Objects.Auditoria>(detailsQuery);
            return res;
        }
        public DO.Objects.Auditoria GetOneById(string id)
        {
            var detailsQuery = new dal.Auditoria().GetOneById(id);
            var res = Mapper.Map<data.Auditoria, DO.Objects.Auditoria>(detailsQuery);
            return res;
        }

        public DO.Objects.Auditoria GetOne(Expression<Func<DO.Objects.Auditoria, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public void Insert(DO.Objects.Auditoria t)
        {
            var ent = Mapper.Map<DO.Objects.Auditoria, data.Auditoria>(t);
            new dal.Auditoria().Insert(ent);
        }

        public void Updated(DO.Objects.Auditoria t)
        {
            var ent = Mapper.Map<DO.Objects.Auditoria, data.Auditoria>(t);
            new dal.Auditoria().Updated(ent);
        }
    }
}
