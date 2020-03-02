using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
            return new Seminario.BS.Correo().GetAll();
        }

        [Route("api/Correo/GetOneById/5")]
        [HttpGet]
        public ent.Correo GetOneById(int id)
        {
            return new Seminario.BS.Correo().GetOneById(id);
        }

        [Route("api/Correo/Delete")]
        [HttpPost]
        public void Delete(ent.Correo t)
        {
            new Seminario.BS.Correo().Delete(t);
        }

        [Route("api/Correo/Update")]
        [HttpPost]
        public void Updated(ent.Correo t)
        {
            new Seminario.BS.Correo().Updated(t);
        }

        [Route("api/Correo/Insert")]
        [HttpPost]
        public void Insert(ent.Correo t)
        {
            new Seminario.BS.Correo().Insert(t);
        }
    }
}
