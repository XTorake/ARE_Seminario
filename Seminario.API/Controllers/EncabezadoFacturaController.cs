using System.Collections.Generic;
using System.Web.Http;
using Seminario.BS;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/EncabezadoFactura")]
    public class EncabezadoFacturaController : ApiController
    {

        [Route("api/EncabezadoFactura/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.EncabezadoFactura> GetAll()
        {
            return new EncabezadoFactura().GetAll();
        }

        [Route("api/EncabezadoFactura/GetOneById/5")]
        [HttpGet]
        public ent.EncabezadoFactura GetOneById(int id)
        {
            return new EncabezadoFactura().GetOneById(id);
        }

        [Route("api/EncabezadoFactura/Delete")]
        [HttpPost]
        public void Delete(ent.EncabezadoFactura t)
        {
            new EncabezadoFactura().Delete(t);
        }

        [Route("api/EncabezadoFactura/Update")]
        [HttpPost]
        public void Updated(ent.EncabezadoFactura t)
        {
            new EncabezadoFactura().Updated(t);
        }

        [Route("api/EncabezadoFactura/Insert")]
        [HttpPost]
        public void Insert(ent.EncabezadoFactura t)
        {
            new EncabezadoFactura().Insert(t);
        }
    }
}
