using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
            return new Seminario.BS.Curso().GetAll();
        }

        [Route("api/Curso/GetOneById/5")]
        [HttpGet]
        public ent.Curso GetOneById(int id)
        {
            return new Seminario.BS.Curso().GetOneById(id);
        }

        [Route("api/Curso/Delete")]
        [HttpPost]
        public void Delete(ent.Curso t)
        {
            new Seminario.BS.Curso().Delete(t);
        }

        [Route("api/Curso/Update")]
        [HttpPost]
        public void Updated(ent.Curso t)
        {
            new Seminario.BS.Curso().Updated(t);
        }

        [Route("api/Curso/Insert")]
        [HttpPost]
        public void Insert(ent.Curso t)
        {
            new Seminario.BS.Curso().Insert(t);
        }
    }
}
