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
    public class Pais : ent.Interfaces.ICRUD<ent.Objects.Pais>
    {
        public void Delete(ent.Objects.Pais t)
        {
            var _ent = Mapper.Map<ent.Objects.Pais, data.Pai>(t);
            new dal.Pais().Delete(_ent);
        }

        public IEnumerable<ent.Objects.Pais> GetAll()
        {
            var DetailsQuery = new dal.Pais().GetAll();
            var res = Mapper.Map<IEnumerable<data.Pai>, IEnumerable<ent.Objects.Pais>>(DetailsQuery);
            return res;
        }

        public ent.Objects.Pais GetOneById(int id)
        {
            var DetailsQuery = new dal.Pais().GetOneById(id);
            var res = Mapper.Map<data.Pai, ent.Objects.Pais>(DetailsQuery);
            return res;
        }

        public void Insert(ent.Objects.Pais t)
        {
            var _ent = Mapper.Map<ent.Objects.Pais, data.Pai>(t);
            new dal.Pais().Insert(_ent);
        }

        public void Updated(ent.Objects.Pais t)
        {
            var _ent = Mapper.Map<ent.Objects.Pais, data.Pai>(t);
            new dal.Pais().Updated(_ent);
        }
    }
}
