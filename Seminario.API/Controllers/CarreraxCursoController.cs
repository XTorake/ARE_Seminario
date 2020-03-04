using System.Collections.Generic;
using System.Web.Http;
using Seminario.BS;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/CarreraxCurso")]
    public class CarreraxCursoController : ApiController
    {

        [Route("api/CarreraxCurso/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.CarreraxCurso> GetAll()
        {
            return new CarreraxCurso().GetAll();
        }

        [Route("api/CarreraxCurso/GetOneById/5")]
        [HttpGet]
        public ent.CarreraxCurso GetOneById(int id)
        {
            return new CarreraxCurso().GetOneById(id);
        }

        [Route("api/CarreraxCurso/Delete")]
        [HttpPost]
        public void Delete(ent.CarreraxCurso t)
        {
            new CarreraxCurso().Delete(t);
        }

        [Route("api/CarreraxCurso/Update")]
        [HttpPost]
        public void Updated(ent.CarreraxCurso t)
        {
            new CarreraxCurso().Updated(t);
        }

        [Route("api/CarreraxCurso/Insert")]
        [HttpPost]
        public void Insert(ent.CarreraxCurso t)
        {
            new CarreraxCurso().Insert(t);
        }
    }
}
