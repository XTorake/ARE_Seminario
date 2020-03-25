using System.Collections.Generic;
using AutoMapper;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;
using ent = Seminario.DO;
using dal = Seminario.DAL;

namespace Seminario.BS
{
    public class Correo : ICrud<DO.Objects.Correo>
    {
        public void Delete(DO.Objects.Correo t)
        {
            var ent = Mapper.Map<DO.Objects.Correo, data.Correo>(t);
            new dal.Correo().Delete(ent);
        }

        public IEnumerable<DO.Objects.Correo> GetAll()
        {
            var detailsQuery = new dal.Correo().GetAll();
            var res = Mapper.Map<IEnumerable<data.Correo>, IEnumerable<DO.Objects.Correo>>(detailsQuery);
            return res;
        }

        public DO.Objects.Correo GetOneById(int id)
        {
            var detailsQuery = new dal.Correo().GetOneById(id);
            var res = Mapper.Map<data.Correo, DO.Objects.Correo>(detailsQuery);
            return res;
        }
        public DO.Objects.Correo GetOneById(string id)
        {
            var detailsQuery = new dal.Correo().GetOneById(id);
            var res = Mapper.Map<data.Correo, DO.Objects.Correo>(detailsQuery);
            return res;
        }
        public void Insert(DO.Objects.Correo t)
        {
            var ent = Mapper.Map<DO.Objects.Correo, data.Correo>(t);
            new dal.Correo().Insert(ent);
        }

        public void Updated(DO.Objects.Correo t)
        {
            var ent = Mapper.Map<DO.Objects.Correo, data.Correo>(t);
            new dal.Correo().Updated(ent);
        }
    }
}
