using System.Collections.Generic;
using AutoMapper;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;
using ent = Seminario.DO;
using dal = Seminario.DAL;

namespace Seminario.BS
{
    public class MetodoPago : ICrud<DO.Objects.MetodoPago>
    {
        public void Delete(DO.Objects.MetodoPago t)
        {
            var ent = Mapper.Map<DO.Objects.MetodoPago, data.MetodoPago>(t);
            new dal.MetodoPago().Delete(ent);
        }

        public IEnumerable<DO.Objects.MetodoPago> GetAll()
        {
            var detailsQuery = new dal.MetodoPago().GetAll();
            var res = Mapper.Map<IEnumerable<data.MetodoPago>, IEnumerable<DO.Objects.MetodoPago>>(detailsQuery);
            return res;
        }

        public DO.Objects.MetodoPago GetOneById(int id)
        {
            var detailsQuery = new dal.MetodoPago().GetOneById(id);
            var res = Mapper.Map<data.MetodoPago, DO.Objects.MetodoPago>(detailsQuery);
            return res;
        }

        public void Insert(DO.Objects.MetodoPago t)
        {
            var ent = Mapper.Map<DO.Objects.MetodoPago, data.MetodoPago>(t);
            new dal.MetodoPago().Insert(ent);
        }

        public void Updated(DO.Objects.MetodoPago t)
        {
            var ent = Mapper.Map<DO.Objects.MetodoPago, data.MetodoPago>(t);
            new dal.MetodoPago().Updated(ent);
        }
    }
}
