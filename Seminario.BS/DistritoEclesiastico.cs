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
    public class DistritoEclesiastico : ent.Interfaces.ICRUD<ent.Objects.DistritoEclesiastico>
    {
        public void Delete(ent.Objects.DistritoEclesiastico t)
        {
            var _ent = Mapper.Map<ent.Objects.DistritoEclesiastico, data.DistritoEclesiastico>(t);
            new dal.DistritoEclesiastico().Delete(_ent);
        }

        public IEnumerable<ent.Objects.DistritoEclesiastico> GetAll()
        {
            var DetailsQuery = new dal.DistritoEclesiastico().GetAll();
            var res = Mapper.Map<IEnumerable<data.DistritoEclesiastico>, IEnumerable<ent.Objects.DistritoEclesiastico>>(DetailsQuery);
            return res;
        }

        public ent.Objects.DistritoEclesiastico GetOneById(int id)
        {
            var DetailsQuery = new dal.DistritoEclesiastico().GetOneById(id);
            var res = Mapper.Map<data.DistritoEclesiastico, ent.Objects.DistritoEclesiastico>(DetailsQuery);
            return res;
        }

        public void Insert(ent.Objects.DistritoEclesiastico t)
        {
            var _ent = Mapper.Map<ent.Objects.DistritoEclesiastico, data.DistritoEclesiastico>(t);
            new dal.DistritoEclesiastico().Insert(_ent);
        }

        public void Updated(ent.Objects.DistritoEclesiastico t)
        {
            var _ent = Mapper.Map<ent.Objects.DistritoEclesiastico, data.DistritoEclesiastico>(t);
            new dal.DistritoEclesiastico().Updated(_ent);
        }
    }
}
