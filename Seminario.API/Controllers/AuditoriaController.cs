using System.Collections.Generic;
using System.Web.Http;
using Seminario.BS;
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
            return new Auditoria().GetAll();
        }

        [Route("api/Auditoria/GetOneById/5")]
        [HttpGet]
        public ent.Auditoria GetOneById(int id)
        {
            return new Auditoria().GetOneById(id);
        }

        [Route("api/Auditoria/Delete")]
        [HttpPost]
        public void Delete(ent.Auditoria t)
        {
            new Auditoria().Delete(t);
        }

        [Route("api/Auditoria/Update")]
        [HttpPost]
        public void Updated(ent.Auditoria t)
        {
            new Auditoria().Updated(t);
        }

        [Route("api/Auditoria/Insert")]
        [HttpPost]
        public void Insert(ent.Auditoria t)
        {
            new Auditoria().Insert(t);
        }
    }
}
