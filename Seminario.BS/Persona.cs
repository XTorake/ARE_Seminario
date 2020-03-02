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
    public class Persona : ent.Interfaces.ICRUD<ent.Objects.Persona>
    {
        public void Delete(ent.Objects.Persona t)
        {
            var _ent = Mapper.Map<ent.Objects.Persona, data.Persona>(t);
            new dal.Persona().Delete(_ent);
        }

        public IEnumerable<ent.Objects.Persona> GetAll()
        {
            var DetailsQuery = new dal.Persona().GetAll();
            var res = Mapper.Map<IEnumerable<data.Persona>, IEnumerable<ent.Objects.Persona>>(DetailsQuery);
            return res;
        }

        public ent.Objects.Persona GetOneById(int id)
        {
            var DetailsQuery = new dal.Persona().GetOneById(id);
            var res = Mapper.Map<data.Persona, ent.Objects.Persona>(DetailsQuery);
            return res;
        }

        public void Insert(ent.Objects.Persona t)
        {
            var _ent = Mapper.Map<ent.Objects.Persona, data.Persona>(t);
            new dal.Persona().Insert(_ent);
        }

        public void Updated(ent.Objects.Persona t)
        {
            var _ent = Mapper.Map<ent.Objects.Persona, data.Persona>(t);
            new dal.Persona().Updated(_ent);
        }
    }
}
