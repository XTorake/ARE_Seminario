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
    public class Curso : ent.Interfaces.ICRUD<ent.Objects.Curso>
    {
        public void Delete(ent.Objects.Curso t)
        {
            var _ent = Mapper.Map<ent.Objects.Curso, data.Curso>(t);
            new dal.Curso().Delete(_ent);
        }

        public IEnumerable<ent.Objects.Curso> GetAll()
        {
            var DetailsQuery = new dal.Curso().GetAll();
            var res = Mapper.Map<IEnumerable<data.Curso>, IEnumerable<ent.Objects.Curso>>(DetailsQuery);
            return res;
        }

        public ent.Objects.Curso GetOneById(int id)
        {
            var DetailsQuery = new dal.Curso().GetOneById(id);
            var res = Mapper.Map<data.Curso, ent.Objects.Curso>(DetailsQuery);
            return res;
        }

        public void Insert(ent.Objects.Curso t)
        {
            var _ent = Mapper.Map<ent.Objects.Curso, data.Curso>(t);
            new dal.Curso().Insert(_ent);
        }

        public void Updated(ent.Objects.Curso t)
        {
            var _ent = Mapper.Map<ent.Objects.Curso, data.Curso>(t);
            new dal.Curso().Updated(_ent);
        }
    }
}
