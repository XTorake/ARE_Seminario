using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/Auditoria")]
    public class AuditoriaController : ApiController
    {

        [Route("api/Auditoria/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.Auditoria> GetAll()
        {
            return new Seminario.BS.Auditoria().GetAll();
        }

        [Route("api/Auditoria/GetOneById/5")]
        [HttpGet]
        public ent.Auditoria GetOneById(int id)
        {
            return new Seminario.BS.Auditoria().GetOneById(id);
        }

        [Route("api/Auditoria/Delete")]
        [HttpPost]
        public void Delete(ent.Auditoria t)
        {
            new Seminario.BS.Auditoria().Delete(t);
        }

        [Route("api/Auditoria/Update")]
        [HttpPost]
        public void Updated(ent.Auditoria t)
        {
            new Seminario.BS.Auditoria().Updated(t);
        }

        [Route("api/Auditoria/Insert")]
        [HttpPost]
        public void Insert(ent.Auditoria t)
        {
            new Seminario.BS.Auditoria().Insert(t);
        }
    }
}
