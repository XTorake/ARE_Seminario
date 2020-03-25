using System.Collections.Generic;
using AutoMapper;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;
using ent = Seminario.DO;
using dal = Seminario.DAL;

namespace Seminario.BS
{
    public class Pais : ICrud<DO.Objects.Pais>
    {
        public void Delete(DO.Objects.Pais t)
        {
            var ent = Mapper.Map<DO.Objects.Pais, data.Pai>(t);
            new dal.Pais().Delete(ent);
        }

        public IEnumerable<DO.Objects.Pais> GetAll()
        {
            var detailsQuery = new dal.Pais().GetAll();
            var res = Mapper.Map<IEnumerable<data.Pai>, IEnumerable<DO.Objects.Pais>>(detailsQuery);
            return res;
        }

        public DO.Objects.Pais GetOneById(int id)
        {
            var detailsQuery = new dal.Pais().GetOneById(id);
            var res = Mapper.Map<data.Pai, DO.Objects.Pais>(detailsQuery);
            return res;
        }
        public DO.Objects.Pais GetOneById(string id)
        {
            var detailsQuery = new dal.Pais().GetOneById(id);
            var res = Mapper.Map<data.Pai, DO.Objects.Pais>(detailsQuery);
            return res;
        }
        public void Insert(DO.Objects.Pais t)
        {
            var ent = Mapper.Map<DO.Objects.Pais, data.Pai>(t);
            new dal.Pais().Insert(ent);
        }

        public void Updated(DO.Objects.Pais t)
        {
            var ent = Mapper.Map<DO.Objects.Pais, data.Pai>(t);
            new dal.Pais().Updated(ent);
        }
    }
}
