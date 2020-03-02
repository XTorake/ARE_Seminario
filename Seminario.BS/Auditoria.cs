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
    public class Auditoria : ent.Interfaces.ICRUD<ent.Objects.Auditoria>
    {
        public void Delete(ent.Objects.Auditoria t)
        {
            var _ent = Mapper.Map<ent.Objects.Auditoria, data.Auditoria>(t);
            new dal.Auditoria().Delete(_ent);
        }

        public IEnumerable<ent.Objects.Auditoria> GetAll()
        {
            var DetailsQuery = new dal.Auditoria().GetAll();
            var res = Mapper.Map<IEnumerable<data.Auditoria>, IEnumerable<ent.Objects.Auditoria>>(DetailsQuery);
            return res;
        }

        public ent.Objects.Auditoria GetOneById(int id)
        {
            var DetailsQuery = new dal.Auditoria().GetOneById(id);
            var res = Mapper.Map<data.Auditoria, ent.Objects.Auditoria>(DetailsQuery);
            return res;
        }

        public void Insert(ent.Objects.Auditoria t)
        {
            var _ent = Mapper.Map<ent.Objects.Auditoria, data.Auditoria>(t);
            new dal.Auditoria().Insert(_ent);
        }

        public void Updated(ent.Objects.Auditoria t)
        {
            var _ent = Mapper.Map<ent.Objects.Auditoria, data.Auditoria>(t);
            new dal.Auditoria().Updated(_ent);
        }
    }
}
