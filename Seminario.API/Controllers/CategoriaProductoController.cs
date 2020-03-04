using System.Collections.Generic;
using System.Web.Http;
using Seminario.BS;
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
            return new CategoriaProducto().GetAll();
        }

        [Route("api/CategoriaProducto/GetOneById/5")]
        [HttpGet]
        public ent.CategoriaProducto GetOneById(int id)
        {
            return new CategoriaProducto().GetOneById(id);
        }

        [Route("api/CategoriaProducto/Delete")]
        [HttpPost]
        public void Delete(ent.CategoriaProducto t)
        {
            new CategoriaProducto().Delete(t);
        }

        [Route("api/CategoriaProducto/Update")]
        [HttpPost]
        public void Updated(ent.CategoriaProducto t)
        {
            new CategoriaProducto().Updated(t);
        }

        [Route("api/CategoriaProducto/Insert")]
        [HttpPost]
        public void Insert(ent.CategoriaProducto t)
        {
            new CategoriaProducto().Insert(t);
        }
    }
}
