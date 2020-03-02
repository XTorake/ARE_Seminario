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
    public class CategoriaProducto : ent.Interfaces.ICRUD<ent.Objects.CategoriaProducto>
    {
        public void Delete(ent.Objects.CategoriaProducto t)
        {
            var _ent = Mapper.Map<ent.Objects.CategoriaProducto, data.CategoriaProducto>(t);
            new dal.CategoriaProducto().Delete(_ent);
        }

        public IEnumerable<ent.Objects.CategoriaProducto> GetAll()
        {
            var DetailsQuery = new dal.CategoriaProducto().GetAll();
            var res = Mapper.Map<IEnumerable<data.CategoriaProducto>, IEnumerable<ent.Objects.CategoriaProducto>>(DetailsQuery);
            return res;
        }

        public ent.Objects.CategoriaProducto GetOneById(int id)
        {
            var DetailsQuery = new dal.CategoriaProducto().GetOneById(id);
            var res = Mapper.Map<data.CategoriaProducto, ent.Objects.CategoriaProducto>(DetailsQuery);
            return res;
        }

        public void Insert(ent.Objects.CategoriaProducto t)
        {
            var _ent = Mapper.Map<ent.Objects.CategoriaProducto, data.CategoriaProducto>(t);
            new dal.CategoriaProducto().Insert(_ent);
        }

        public void Updated(ent.Objects.CategoriaProducto t)
        {
            var _ent = Mapper.Map<ent.Objects.CategoriaProducto, data.CategoriaProducto>(t);
            new dal.CategoriaProducto().Updated(_ent);
        }
    }
}
