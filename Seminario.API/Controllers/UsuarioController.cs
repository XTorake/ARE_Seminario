using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/Usuario")]
    public class UsuarioController : ApiController
    {

        [Route("api/Usuario/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.Usuario> GetAll()
        {
            return new Seminario.BS.Usuario().GetAll();
        }

        [Route("api/Usuario/GetOneById/5")]
        [HttpGet]
        public ent.Usuario GetOneById(int id)
        {
            return new Seminario.BS.Usuario().GetOneById(id);
        }

        [Route("api/Usuario/Delete")]
        [HttpPost]
        public void Delete(ent.Usuario t)
        {
            new Seminario.BS.Usuario().Delete(t);
        }

        [Route("api/Usuario/Update")]
        [HttpPost]
        public void Updated(ent.Usuario t)
        {
            new Seminario.BS.Usuario().Updated(t);
        }

        [Route("api/Usuario/Insert")]
        [HttpPost]
        public void Insert(ent.Usuario t)
        {
            new Seminario.BS.Usuario().Insert(t);
        }
    }
}
