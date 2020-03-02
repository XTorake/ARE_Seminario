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
    public class Producto : ent.Interfaces.ICRUD<ent.Objects.Producto>
    {
        public void Delete(ent.Objects.Producto t)
        {
            var _ent = Mapper.Map<ent.Objects.Producto, data.Producto>(t);
            new dal.Producto().Delete(_ent);
        }

        public IEnumerable<ent.Objects.Producto> GetAll()
        {
            var DetailsQuery = new dal.Producto().GetAll();
            var res = Mapper.Map<IEnumerable<data.Producto>, IEnumerable<ent.Objects.Producto>>(DetailsQuery);
            return res;
        }

        public ent.Objects.Producto GetOneById(int id)
        {
            var DetailsQuery = new dal.Producto().GetOneById(id);
            var res = Mapper.Map<data.Producto, ent.Objects.Producto>(DetailsQuery);
            return res;
        }

        public void Insert(ent.Objects.Producto t)
        {
            var _ent = Mapper.Map<ent.Objects.Producto, data.Producto>(t);
            new dal.Producto().Insert(_ent);
        }

        public void Updated(ent.Objects.Producto t)
        {
            var _ent = Mapper.Map<ent.Objects.Producto, data.Producto>(t);
            new dal.Producto().Updated(_ent);
        }
    }
}
