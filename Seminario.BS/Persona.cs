using System.Collections.Generic;
using AutoMapper;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;
using ent = Seminario.DO;
using dal = Seminario.DAL;

namespace Seminario.BS
{
    public class Persona : ICrud<DO.Objects.Persona>
    {
        public void Delete(DO.Objects.Persona t)
        {
            var ent = Mapper.Map<DO.Objects.Persona, data.Persona>(t);
            new dal.Persona().Delete(ent);
        }

        public IEnumerable<DO.Objects.Persona> GetAll()
        {
            var detailsQuery = new dal.Persona().GetAll();
            var res = Mapper.Map<IEnumerable<data.Persona>, IEnumerable<DO.Objects.Persona>>(detailsQuery);
            return res;
        }

        public DO.Objects.Persona GetOneById(int id)
        {
            var detailsQuery = new dal.Persona().GetOneById(id);
            var res = Mapper.Map<data.Persona, DO.Objects.Persona>(detailsQuery);
            return res;
        }
        public DO.Objects.Persona GetOneById(string id)
        {
            var detailsQuery = new dal.Persona().GetOneById(id);
            var res = Mapper.Map<data.Persona, DO.Objects.Persona>(detailsQuery);
            return res;
        }
        public void Insert(DO.Objects.Persona t)
        {
            var ent = Mapper.Map<DO.Objects.Persona, data.Persona>(t);
            new dal.Persona().Insert(ent);
        }

        public void Updated(DO.Objects.Persona t)
        {
            var ent = Mapper.Map<DO.Objects.Persona, data.Persona>(t);
            new dal.Persona().Updated(ent);
        }
    }
}
