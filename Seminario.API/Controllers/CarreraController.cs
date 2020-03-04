using System.Collections.Generic;
using System.Web.Http;
using Seminario.BS;
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
            return new Carrera().GetAll();
        }

        [Route("api/Carrera/GetOneById/5")]
        [HttpGet]
        public ent.Carrera GetOneById(int id)
        {
            return new Carrera().GetOneById(id);
        }

        [Route("api/Carrera/Delete")]
        [HttpPost]
        public void Delete(ent.Carrera t)
        {
            new Carrera().Delete(t);
        }

        [Route("api/Carrera/Update")]
        [HttpPost]
        public void Updated(ent.Carrera t)
        {
            new Carrera().Updated(t);
        }

        [Route("api/Carrera/Insert")]
        [HttpPost]
        public void Insert(ent.Carrera t)
        {
            new Carrera().Insert(t);
        }
    }
}
