using System.Collections.Generic;
using System.Web.Http;
using Seminario.BS;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/Telefono")]
    public class TelefonoController : ApiController
    {

        [Route("api/Telefono/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.Telefono> GetAll()
        {
            return new Telefono().GetAll();
        }

        [Route("api/Telefono/GetOneById/5")]
        [HttpGet]
        public ent.Telefono GetOneById(int id)
        {
            return new Telefono().GetOneById(id);
        }

        [Route("api/Telefono/Delete")]
        [HttpPost]
        public void Delete(ent.Telefono t)
        {
            new Telefono().Delete(t);
        }

        [Route("api/Telefono/Update")]
        [HttpPost]
        public void Updated(ent.Telefono t)
        {
            new Telefono().Updated(t);
        }

        [Route("api/Telefono/Insert")]
        [HttpPost]
        public void Insert(ent.Telefono t)
        {
            new Telefono().Insert(t);
        }
    }
}
