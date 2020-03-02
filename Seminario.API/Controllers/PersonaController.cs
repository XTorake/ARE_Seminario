using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/Persona")]
    public class PersonaController : ApiController
    {

        [Route("api/Persona/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.Persona> GetAll()
        {
            return new Seminario.BS.Persona().GetAll();
        }

        [Route("api/Persona/GetOneById/5")]
        [HttpGet]
        public ent.Persona GetOneById(int id)
        {
            return new Seminario.BS.Persona().GetOneById(id);
        }

        [Route("api/Persona/Delete")]
        [HttpPost]
        public void Delete(ent.Persona t)
        {
            new Seminario.BS.Persona().Delete(t);
        }

        [Route("api/Persona/Update")]
        [HttpPost]
        public void Updated(ent.Persona t)
        {
            new Seminario.BS.Persona().Updated(t);
        }

        [Route("api/Persona/Insert")]
        [HttpPost]
        public void Insert(ent.Persona t)
        {
            new Seminario.BS.Persona().Insert(t);
        }
    }
}
