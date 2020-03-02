using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/CategoriaProducto")]
    public class CategoriaProductoController : ApiController
    {

        [Route("api/CategoriaProducto/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.CategoriaProducto> GetAll()
        {
            return new Seminario.BS.CategoriaProducto().GetAll();
        }

        [Route("api/CategoriaProducto/GetOneById/5")]
        [HttpGet]
        public ent.CategoriaProducto GetOneById(int id)
        {
            return new Seminario.BS.CategoriaProducto().GetOneById(id);
        }

        [Route("api/CategoriaProducto/Delete")]
        [HttpPost]
        public void Delete(ent.CategoriaProducto t)
        {
            new Seminario.BS.CategoriaProducto().Delete(t);
        }

        [Route("api/CategoriaProducto/Update")]
        [HttpPost]
        public void Updated(ent.CategoriaProducto t)
        {
            new Seminario.BS.CategoriaProducto().Updated(t);
        }

        [Route("api/CategoriaProducto/Insert")]
        [HttpPost]
        public void Insert(ent.CategoriaProducto t)
        {
            new Seminario.BS.CategoriaProducto().Insert(t);
        }
    }
}
