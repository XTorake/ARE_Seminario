using System.Collections.Generic;
using System.Web.Http;
using Seminario.BS;
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
            return new Iglesia().GetAll();
        }

        [Route("api/Iglesia/GetOneById/5")]
        [HttpGet]
        public ent.Iglesia GetOneById(int id)
        {
            return new Iglesia().GetOneById(id);
        }

        [Route("api/Iglesia/Delete")]
        [HttpPost]
        public void Delete(ent.Iglesia t)
        {
            new Iglesia().Delete(t);
        }

        [Route("api/Iglesia/Update")]
        [HttpPost]
        public void Updated(ent.Iglesia t)
        {
            new Iglesia().Updated(t);
        }

        [Route("api/Iglesia/Insert")]
        [HttpPost]
        public void Insert(ent.Iglesia t)
        {
            new Iglesia().Insert(t);
        }
    }
}
