using System.Collections.Generic;
using System.Web.Http;
using Seminario.BS;
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
            return new DistritoEclesiastico().GetAll();
        }

        [Route("api/DistritoEclesiastico/GetOneById/5")]
        [HttpGet]
        public ent.DistritoEclesiastico GetOneById(int id)
        {
            return new DistritoEclesiastico().GetOneById(id);
        }

        [Route("api/DistritoEclesiastico/Delete")]
        [HttpPost]
        public void Delete(ent.DistritoEclesiastico t)
        {
            new DistritoEclesiastico().Delete(t);
        }

        [Route("api/DistritoEclesiastico/Update")]
        [HttpPost]
        public void Updated(ent.DistritoEclesiastico t)
        {
            new DistritoEclesiastico().Updated(t);
        }

        [Route("api/DistritoEclesiastico/Insert")]
        [HttpPost]
        public void Insert(ent.DistritoEclesiastico t)
        {
            new DistritoEclesiastico().Insert(t);
        }
    }
}
