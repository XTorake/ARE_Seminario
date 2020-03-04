using System.Collections.Generic;
using AutoMapper;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;
using ent = Seminario.DO;
using dal = Seminario.DAL;

namespace Seminario.BS
{
    public class Curso : ICrud<DO.Objects.Curso>
    {
        public void Delete(DO.Objects.Curso t)
        {
            var ent = Mapper.Map<DO.Objects.Curso, data.Curso>(t);
            new dal.Curso().Delete(ent);
        }

        public IEnumerable<DO.Objects.Curso> GetAll()
        {
            var detailsQuery = new dal.Curso().GetAll();
            var res = Mapper.Map<IEnumerable<data.Curso>, IEnumerable<DO.Objects.Curso>>(detailsQuery);
            return res;
        }

        public DO.Objects.Curso GetOneById(int id)
        {
            var detailsQuery = new dal.Curso().GetOneById(id);
            var res = Mapper.Map<data.Curso, DO.Objects.Curso>(detailsQuery);
            return res;
        }

        public void Insert(DO.Objects.Curso t)
        {
            var ent = Mapper.Map<DO.Objects.Curso, data.Curso>(t);
            new dal.Curso().Insert(ent);
        }

        public void Updated(DO.Objects.Curso t)
        {
            var ent = Mapper.Map<DO.Objects.Curso, data.Curso>(t);
            new dal.Curso().Updated(ent);
        }
    }
}
