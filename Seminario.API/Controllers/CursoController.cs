using System.Collections.Generic;
using System.Web.Http;
using Seminario.BS;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/Curso")]
    public class CursoController : ApiController
    {

        [Route("api/Curso/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.Curso> GetAll()
        {
            return new Curso().GetAll();
        }

        [Route("api/Curso/GetOneById/5")]
        [HttpGet]
        public ent.Curso GetOneById(int id)
        {
            return new Curso().GetOneById(id);
        }

        [Route("api/Curso/Delete")]
        [HttpPost]
        public void Delete(ent.Curso t)
        {
            new Curso().Delete(t);
        }

        [Route("api/Curso/Update")]
        [HttpPost]
        public void Updated(ent.Curso t)
        {
            new Curso().Updated(t);
        }

        [Route("api/Curso/Insert")]
        [HttpPost]
        public void Insert(ent.Curso t)
        {
            new Curso().Insert(t);
        }
    }
}
