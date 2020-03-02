using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
            return new Seminario.BS.EncabezadoFactura().GetAll();
        }

        [Route("api/EncabezadoFactura/GetOneById/5")]
        [HttpGet]
        public ent.EncabezadoFactura GetOneById(int id)
        {
            return new Seminario.BS.EncabezadoFactura().GetOneById(id);
        }

        [Route("api/EncabezadoFactura/Delete")]
        [HttpPost]
        public void Delete(ent.EncabezadoFactura t)
        {
            new Seminario.BS.EncabezadoFactura().Delete(t);
        }

        [Route("api/EncabezadoFactura/Update")]
        [HttpPost]
        public void Updated(ent.EncabezadoFactura t)
        {
            new Seminario.BS.EncabezadoFactura().Updated(t);
        }

        [Route("api/EncabezadoFactura/Insert")]
        [HttpPost]
        public void Insert(ent.EncabezadoFactura t)
        {
            new Seminario.BS.EncabezadoFactura().Insert(t);
        }
    }
}
