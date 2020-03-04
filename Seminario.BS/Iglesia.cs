using System.Collections.Generic;
using AutoMapper;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;
using ent = Seminario.DO;
using dal = Seminario.DAL;

namespace Seminario.BS
{
    public class Iglesia : ICrud<DO.Objects.Iglesia>
    {
        public void Delete(DO.Objects.Iglesia t)
        {
            var ent = Mapper.Map<DO.Objects.Iglesia, data.Iglesia>(t);
            new dal.Iglesia().Delete(ent);
        }

        public IEnumerable<DO.Objects.Iglesia> GetAll()
        {
            var detailsQuery = new dal.Iglesia().GetAll();
            var res = Mapper.Map<IEnumerable<data.Iglesia>, IEnumerable<DO.Objects.Iglesia>>(detailsQuery);
            return res;
        }

        public DO.Objects.Iglesia GetOneById(int id)
        {
            var detailsQuery = new dal.Iglesia().GetOneById(id);
            var res = Mapper.Map<data.Iglesia, DO.Objects.Iglesia>(detailsQuery);
            return res;
        }

        public void Insert(DO.Objects.Iglesia t)
        {
            var ent = Mapper.Map<DO.Objects.Iglesia, data.Iglesia>(t);
            new dal.Iglesia().Insert(ent);
        }

        public void Updated(DO.Objects.Iglesia t)
        {
            var ent = Mapper.Map<DO.Objects.Iglesia, data.Iglesia>(t);
            new dal.Iglesia().Updated(ent);
        }
    }
}
