using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
            return new Seminario.BS.TipoUsuario().GetAll();
        }

        [Route("api/TipoUsuario/GetOneById/5")]
        [HttpGet]
        public ent.TipoUsuario GetOneById(int id)
        {
            return new Seminario.BS.TipoUsuario().GetOneById(id);
        }

        [Route("api/TipoUsuario/Delete")]
        [HttpPost]
        public void Delete(ent.TipoUsuario t)
        {
            new Seminario.BS.TipoUsuario().Delete(t);
        }

        [Route("api/TipoUsuario/Update")]
        [HttpPost]
        public void Updated(ent.TipoUsuario t)
        {
            new Seminario.BS.TipoUsuario().Updated(t);
        }

        [Route("api/TipoUsuario/Insert")]
        [HttpPost]
        public void Insert(ent.TipoUsuario t)
        {
            new Seminario.BS.TipoUsuario().Insert(t);
        }
    }
}