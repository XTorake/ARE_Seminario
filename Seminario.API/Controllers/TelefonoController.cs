using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
            return new Seminario.BS.Telefono().GetAll();
        }

        [Route("api/Telefono/GetOneById/5")]
        [HttpGet]
        public ent.Telefono GetOneById(int id)
        {
            return new Seminario.BS.Telefono().GetOneById(id);
        }

        [Route("api/Telefono/Delete")]
        [HttpPost]
        public void Delete(ent.Telefono t)
        {
            new Seminario.BS.Telefono().Delete(t);
        }

        [Route("api/Telefono/Update")]
        [HttpPost]
        public void Updated(ent.Telefono t)
        {
            new Seminario.BS.Telefono().Updated(t);
        }

        [Route("api/Telefono/Insert")]
        [HttpPost]
        public void Insert(ent.Telefono t)
        {
            new Seminario.BS.Telefono().Insert(t);
        }
    }
}
