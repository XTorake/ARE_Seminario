using System.Collections.Generic;
using AutoMapper;
using Seminario.DO.Interfaces;
using data = Seminario.DAL.EF;
using ent = Seminario.DO;
using dal = Seminario.DAL;

namespace Seminario.BS
{
    public class CategoriaProducto : ICrud<DO.Objects.CategoriaProducto>
    {
        public void Delete(DO.Objects.CategoriaProducto t)
        {
            var ent = Mapper.Map<DO.Objects.CategoriaProducto, data.CategoriaProducto>(t);
            new dal.CategoriaProducto().Delete(ent);
        }

        public IEnumerable<DO.Objects.CategoriaProducto> GetAll()
        {
            var detailsQuery = new dal.CategoriaProducto().GetAll();
            var res = Mapper.Map<IEnumerable<data.CategoriaProducto>, IEnumerable<DO.Objects.CategoriaProducto>>(detailsQuery);
            return res;
        }

        public DO.Objects.CategoriaProducto GetOneById(int id)
        {
            var detailsQuery = new dal.CategoriaProducto().GetOneById(id);
            var res = Mapper.Map<data.CategoriaProducto, DO.Objects.CategoriaProducto>(detailsQuery);
            return res;
        }
        public DO.Objects.CategoriaProducto GetOneById(string id)
        {
            var detailsQuery = new dal.CategoriaProducto().GetOneById(id);
            var res = Mapper.Map<data.CategoriaProducto, DO.Objects.CategoriaProducto>(detailsQuery);
            return res;
        }
        public void Insert(DO.Objects.CategoriaProducto t)
        {
            var ent = Mapper.Map<DO.Objects.CategoriaProducto, data.CategoriaProducto>(t);
            new dal.CategoriaProducto().Insert(ent);
        }

        public void Updated(DO.Objects.CategoriaProducto t)
        {
            var ent = Mapper.Map<DO.Objects.CategoriaProducto, data.CategoriaProducto>(t);
            new dal.CategoriaProducto().Updated(ent);
        }
    }
}
