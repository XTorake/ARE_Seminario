using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/Carrera")]
    public class CarreraController : ApiController
    {

        [Route("api/Carrera/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.Carrera> GetAll()
        {
            return new Seminario.BS.Carrera().GetAll();
        }

        [Route("api/Carrera/GetOneById/5")]
        [HttpGet]
        public ent.Carrera GetOneById(int id)
        {
            return new Seminario.BS.Carrera().GetOneById(id);
        }

        [Route("api/Carrera/Delete")]
        [HttpPost]
        public void Delete(ent.Carrera t)
        {
            new Seminario.BS.Carrera().Delete(t);
        }

        [Route("api/Carrera/Update")]
        [HttpPost]
        public void Updated(ent.Carrera t)
        {
            new Seminario.BS.Carrera().Updated(t);
        }

        [Route("api/Carrera/Insert")]
        [HttpPost]
        public void Insert(ent.Carrera t)
        {
            new Seminario.BS.Carrera().Insert(t);
        }
    }
}
