using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/MetodoPago")]
    public class MetodoPagoController : ApiController
    {

        [Route("api/MetodoPago/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.MetodoPago> GetAll()
        {
            return new Seminario.BS.MetodoPago().GetAll();
        }

        [Route("api/MetodoPago/GetOneById/5")]
        [HttpGet]
        public ent.MetodoPago GetOneById(int id)
        {
            return new Seminario.BS.MetodoPago().GetOneById(id);
        }

        [Route("api/MetodoPago/Delete")]
        [HttpPost]
        public void Delete(ent.MetodoPago t)
        {
            new Seminario.BS.MetodoPago().Delete(t);
        }

        [Route("api/MetodoPago/Update")]
        [HttpPost]
        public void Updated(ent.MetodoPago t)
        {
            new Seminario.BS.MetodoPago().Updated(t);
        }

        [Route("api/MetodoPago/Insert")]
        [HttpPost]
        public void Insert(ent.MetodoPago t)
        {
            new Seminario.BS.MetodoPago().Insert(t);
        }
    }
}
