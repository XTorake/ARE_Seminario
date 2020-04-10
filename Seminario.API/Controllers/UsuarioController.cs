using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Http;
using Seminario.BS;
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
            return new Usuario().GetAll();
        }
        [Route("api/Usuario/GetOne/5")]
        [HttpGet]
        public ent.Usuario GetOne(string usuario)
        {
            Expression<Func<DO.Objects.Usuario, bool>> predicado = x => x.Usuario1 == usuario;

            return new Usuario().GetOne(predicado);
        }

        [Route("api/Usuario/GetOneById/5")]
        [HttpGet]
        public ent.Usuario GetOneById(int id)
        {
            return new Usuario().GetOneById(id);
        }
        [Route("api/Usuario/GetOneByString/5")]
        [HttpGet]
        public ent.Usuario GetOneById(string id)
        {
            return new Usuario().GetOneById(id);
        }

        [Route("api/Usuario/Delete")]
        [HttpPost]
        public void Delete(ent.Usuario t)
        {
            new Usuario().Delete(t);
        }

        [Route("api/Usuario/Update")]
        [HttpPost]
        public void Updated(ent.Usuario t)
        {
            new Usuario().Updated(t);
        }

        [Route("api/Usuario/Insert")]
        [HttpPost]
        public void Insert(ent.Usuario t)
        {
            new Usuario().Insert(t);
        }
    }
}
