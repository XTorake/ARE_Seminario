using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ent = Seminario.DO.Objects;

namespace Seminario.API.Controllers
{
    [Route("api/DistritoEclesiastico")]
    public class DistritoEclesiasticoController : ApiController
    {

        [Route("api/DistritoEclesiastico/GetAll/")]
        [HttpGet]
        public IEnumerable<ent.DistritoEclesiastico> GetAll()
        {
            return new Seminario.BS.DistritoEclesiastico().GetAll();
        }

        [Route("api/DistritoEclesiastico/GetOneById/5")]
        [HttpGet]
        public ent.DistritoEclesiastico GetOneById(int id)
        {
            return new Seminario.BS.DistritoEclesiastico().GetOneById(id);
        }

        [Route("api/DistritoEclesiastico/Delete")]
        [HttpPost]
        public void Delete(ent.DistritoEclesiastico t)
        {
            new Seminario.BS.DistritoEclesiastico().Delete(t);
        }

        [Route("api/DistritoEclesiastico/Update")]
        [HttpPost]
        public void Updated(ent.DistritoEclesiastico t)
        {
            new Seminario.BS.DistritoEclesiastico().Updated(t);
        }

        [Route("api/DistritoEclesiastico/Insert")]
        [HttpPost]
        public void Insert(ent.DistritoEclesiastico t)
        {
            new Seminario.BS.DistritoEclesiastico().Insert(t);
        }
    }
}
