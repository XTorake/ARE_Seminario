using System.Collections.Generic;
using System.Web.Http;
using Seminario.BS;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/TipoUsuario")]
    public class TipoUsuarioController : ApiController
    {

        [Route("api/TipoUsuario/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.TipoUsuario> GetAll()
        {
            return new TipoUsuario().GetAll();
        }

        [Route("api/TipoUsuario/GetOneById/5")]
        [HttpGet]
        public ent.TipoUsuario GetOneById(int id)
        {
            return new TipoUsuario().GetOneById(id);
        }

        [Route("api/TipoUsuario/Delete")]
        [HttpPost]
        public void Delete(ent.TipoUsuario t)
        {
            new TipoUsuario().Delete(t);
        }

        [Route("api/TipoUsuario/Update")]
        [HttpPost]
        public void Updated(ent.TipoUsuario t)
        {
            new TipoUsuario().Updated(t);
        }

        [Route("api/TipoUsuario/Insert")]
        [HttpPost]
        public void Insert(ent.TipoUsuario t)
        {
            new TipoUsuario().Insert(t);
        }
    }
}