using System.Collections.Generic;
using AutoMapper;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;
using ent = Seminario.DO;
using dal = Seminario.DAL;

namespace Seminario.BS
{
    public class CarreraxCurso : ICrud<DO.Objects.CarreraxCurso>
    {
        public void Delete(DO.Objects.CarreraxCurso t)
        {
            var ent = Mapper.Map<DO.Objects.CarreraxCurso, data.CarreraxCurso>(t);
            new dal.CarreraxCurso().Delete(ent);
        }

        public IEnumerable<DO.Objects.CarreraxCurso> GetAll()
        {
            var detailsQuery = new dal.CarreraxCurso().GetAll();
            var res = Mapper.Map<IEnumerable<data.CarreraxCurso>, IEnumerable<DO.Objects.CarreraxCurso>>(detailsQuery);
            return res;
        }

        public DO.Objects.CarreraxCurso GetOneById(int id)
        {
            var detailsQuery = new dal.CarreraxCurso().GetOneById(id);
            var res = Mapper.Map<data.CarreraxCurso, DO.Objects.CarreraxCurso>(detailsQuery);
            return res;
        }

        public void Insert(DO.Objects.CarreraxCurso t)
        {
            var ent = Mapper.Map<DO.Objects.CarreraxCurso, data.CarreraxCurso>(t);
            new dal.CarreraxCurso().Insert(ent);
        }

        public void Updated(DO.Objects.CarreraxCurso t)
        {
            var ent = Mapper.Map<DO.Objects.CarreraxCurso, data.CarreraxCurso>(t);
            new dal.CarreraxCurso().Updated(ent);
        }
    }
}
