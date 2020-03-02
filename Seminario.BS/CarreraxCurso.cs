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
    public class CarreraxCurso : ent.Interfaces.ICRUD<ent.Objects.CarreraxCurso>
    {
        public void Delete(ent.Objects.CarreraxCurso t)
        {
            var _ent = Mapper.Map<ent.Objects.CarreraxCurso, data.CarreraxCurso>(t);
            new dal.CarreraxCurso().Delete(_ent);
        }

        public IEnumerable<ent.Objects.CarreraxCurso> GetAll()
        {
            var DetailsQuery = new dal.CarreraxCurso().GetAll();
            var res = Mapper.Map<IEnumerable<data.CarreraxCurso>, IEnumerable<ent.Objects.CarreraxCurso>>(DetailsQuery);
            return res;
        }

        public ent.Objects.CarreraxCurso GetOneById(int id)
        {
            var DetailsQuery = new dal.CarreraxCurso().GetOneById(id);
            var res = Mapper.Map<data.CarreraxCurso, ent.Objects.CarreraxCurso>(DetailsQuery);
            return res;
        }

        public void Insert(ent.Objects.CarreraxCurso t)
        {
            var _ent = Mapper.Map<ent.Objects.CarreraxCurso, data.CarreraxCurso>(t);
            new dal.CarreraxCurso().Insert(_ent);
        }

        public void Updated(ent.Objects.CarreraxCurso t)
        {
            var _ent = Mapper.Map<ent.Objects.CarreraxCurso, data.CarreraxCurso>(t);
            new dal.CarreraxCurso().Updated(_ent);
        }
    }
}
