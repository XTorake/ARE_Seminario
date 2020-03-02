using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/LineaFactura")]
    public class LineaFacturaController : ApiController
    {

        [Route("api/LineaFactura/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.LineaFactura> GetAll()
        {
            return new Seminario.BS.LineaFactura().GetAll();
        }

        [Route("api/LineaFactura/GetOneById/5")]
        [HttpGet]
        public ent.LineaFactura GetOneById(int id)
        {
            return new Seminario.BS.LineaFactura().GetOneById(id);
        }

        [Route("api/LineaFactura/Delete")]
        [HttpPost]
        public void Delete(ent.LineaFactura t)
        {
            new Seminario.BS.LineaFactura().Delete(t);
        }

        [Route("api/LineaFactura/Update")]
        [HttpPost]
        public void Updated(ent.LineaFactura t)
        {
            new Seminario.BS.LineaFactura().Updated(t);
        }

        [Route("api/LineaFactura/Insert")]
        [HttpPost]
        public void Insert(ent.LineaFactura t)
        {
            new Seminario.BS.LineaFactura().Insert(t);
        }
    }
}
