using System.Collections.Generic;
using System.Web.Http;
using Seminario.BS;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/Pais")]
    public class PaisController : ApiController
    {

        [Route("api/Pais/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.Pais> GetAll()
        {
            return new Pais().GetAll();
        }

        [Route("api/Pais/GetOneById/5")]
        [HttpGet]
        public ent.Pais GetOneById(int id)
        {
            return new Pais().GetOneById(id);
        }

        [Route("api/Pais/Delete")]
        [HttpPost]
        public void Delete(ent.Pais t)
        {
            new Pais().Delete(t);
        }

        [Route("api/Pais/Update")]
        [HttpPost]
        public void Updated(ent.Pais t)
        {
            new Pais().Updated(t);
        }

        [Route("api/Pais/Insert")]
        [HttpPost]
        public void Insert(ent.Pais t)
        {
            new Pais().Insert(t);
        }
    }
}
