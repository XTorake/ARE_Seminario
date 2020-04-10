using System.Collections.Generic;
using System.Web.Http;
using Seminario.BS;
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
            return new Persona().GetAll();
        }

        [Route("api/Persona/GetOneById/5")]
        [HttpGet]
        public ent.Persona GetOneById(int id)
        {
            return new Persona().GetOneById(id);
        }
        [Route("api/Persona/GetOneByString/5")]
        [HttpGet]
        public ent.Persona GetOneById(string id)
        {
            return new Persona().GetOneById(id);
        }

        [Route("api/Persona/Delete")]
        [HttpPost]
        public void Delete(ent.Persona t)
        {
            new Persona().Delete(t);
        }

        [Route("api/Persona/Update")]
        [HttpPost]
        public void Updated(ent.Persona t)
        {
            new Persona().Updated(t);
        }

        [Route("api/Persona/Insert")]
        [HttpPost]
        public void Insert(ent.Persona t)
        {
            new Persona().Insert(t);
        }
    }
}
