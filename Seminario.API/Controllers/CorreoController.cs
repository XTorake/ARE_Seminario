using System.Collections.Generic;
using System.Web.Http;
using Seminario.BS;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/Correo")]
    public class CorreoController : ApiController
    {

        [Route("api/Correo/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.Correo> GetAll()
        {
            return new Correo().GetAll();
        }

        [Route("api/Correo/GetOneById/5")]
        [HttpGet]
        public ent.Correo GetOneById(int id)
        {
            return new Correo().GetOneById(id);
        }

        [Route("api/Correo/Delete")]
        [HttpPost]
        public void Delete(ent.Correo t)
        {
            new Correo().Delete(t);
        }

        [Route("api/Correo/Update")]
        [HttpPost]
        public void Updated(ent.Correo t)
        {
            new Correo().Updated(t);
        }

        [Route("api/Correo/Insert")]
        [HttpPost]
        public void Insert(ent.Correo t)
        {
            new Correo().Insert(t);
        }
    }
}
