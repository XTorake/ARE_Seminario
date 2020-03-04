using System.Collections.Generic;
using AutoMapper;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;
using ent = Seminario.DO;
using dal = Seminario.DAL;

namespace Seminario.BS
{
    public class Telefono : ICrud<DO.Objects.Telefono>
    {
        public void Delete(DO.Objects.Telefono t)
        {
            var ent = Mapper.Map<DO.Objects.Telefono, data.Telefono>(t);
            new dal.Telefono().Delete(ent);
        }

        public IEnumerable<DO.Objects.Telefono> GetAll()
        {
            var detailsQuery = new dal.Telefono().GetAll();
            var res = Mapper.Map<IEnumerable<data.Telefono>, IEnumerable<DO.Objects.Telefono>>(detailsQuery);
            return res;
        }

        public DO.Objects.Telefono GetOneById(int id)
        {
            var detailsQuery = new dal.Telefono().GetOneById(id);
            var res = Mapper.Map<data.Telefono, DO.Objects.Telefono>(detailsQuery);
            return res;
        }

        public void Insert(DO.Objects.Telefono t)
        {
            var ent = Mapper.Map<DO.Objects.Telefono, data.Telefono>(t);
            new dal.Telefono().Insert(ent);
        }

        public void Updated(DO.Objects.Telefono t)
        {
            var ent = Mapper.Map<DO.Objects.Telefono, data.Telefono>(t);
            new dal.Telefono().Updated(ent);
        }
    }
}
