using System.Collections.Generic;
using System.Web.Http;
using Seminario.BS;
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
            return new LineaFactura().GetAll();
        }

        [Route("api/LineaFactura/GetOneById/5")]
        [HttpGet]
        public ent.LineaFactura GetOneById(int id)
        {
            return new LineaFactura().GetOneById(id);
        }

        [Route("api/LineaFactura/Delete")]
        [HttpPost]
        public void Delete(ent.LineaFactura t)
        {
            new LineaFactura().Delete(t);
        }

        [Route("api/LineaFactura/Update")]
        [HttpPost]
        public void Updated(ent.LineaFactura t)
        {
            new LineaFactura().Updated(t);
        }

        [Route("api/LineaFactura/Insert")]
        [HttpPost]
        public void Insert(ent.LineaFactura t)
        {
            new LineaFactura().Insert(t);
        }
    }
}
