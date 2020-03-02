using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/Iglesia")]
    public class IglesiaController : ApiController
    {

        [Route("api/Iglesia/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.Iglesia> GetAll()
        {
            return new Seminario.BS.Iglesia().GetAll();
        }

        [Route("api/Iglesia/GetOneById/5")]
        [HttpGet]
        public ent.Iglesia GetOneById(int id)
        {
            return new Seminario.BS.Iglesia().GetOneById(id);
        }

        [Route("api/Iglesia/Delete")]
        [HttpPost]
        public void Delete(ent.Iglesia t)
        {
            new Seminario.BS.Iglesia().Delete(t);
        }

        [Route("api/Iglesia/Update")]
        [HttpPost]
        public void Updated(ent.Iglesia t)
        {
            new Seminario.BS.Iglesia().Updated(t);
        }

        [Route("api/Iglesia/Insert")]
        [HttpPost]
        public void Insert(ent.Iglesia t)
        {
            new Seminario.BS.Iglesia().Insert(t);
        }
    }
}
