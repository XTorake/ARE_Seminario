using System.Collections.Generic;
using System.Web.Http;
using Seminario.BS;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/Producto")]
    public class ProductoController : ApiController
    {

        [Route("api/Producto/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.Producto> GetAll()
        {
            return new Producto().GetAll();
        }

        [Route("api/Producto/GetOneById/5")]
        [HttpGet]
        public ent.Producto GetOneById(int id)
        {
            return new Producto().GetOneById(id);
        }

        [Route("api/Producto/Delete")]
        [HttpPost]
        public void Delete(ent.Producto t)
        {
            new Producto().Delete(t);
        }

        [Route("api/Producto/Update")]
        [HttpPost]
        public void Updated(ent.Producto t)
        {
            new Producto().Updated(t);
        }

        [Route("api/Producto/Insert")]
        [HttpPost]
        public void Insert(ent.Producto t)
        {
            new Producto().Insert(t);
        }
    }
}
