using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
            return new Seminario.BS.CarreraxCurso().GetAll();
        }

        [Route("api/CarreraxCurso/GetOneById/5")]
        [HttpGet]
        public ent.CarreraxCurso GetOneById(int id)
        {
            return new Seminario.BS.CarreraxCurso().GetOneById(id);
        }

        [Route("api/CarreraxCurso/Delete")]
        [HttpPost]
        public void Delete(ent.CarreraxCurso t)
        {
            new Seminario.BS.CarreraxCurso().Delete(t);
        }

        [Route("api/CarreraxCurso/Update")]
        [HttpPost]
        public void Updated(ent.CarreraxCurso t)
        {
            new Seminario.BS.CarreraxCurso().Updated(t);
        }

        [Route("api/CarreraxCurso/Insert")]
        [HttpPost]
        public void Insert(ent.CarreraxCurso t)
        {
            new Seminario.BS.CarreraxCurso().Insert(t);
        }
    }
}
