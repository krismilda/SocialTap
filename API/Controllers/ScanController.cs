using System.Web.Http;
using DataAccess;
using DataModels;

namespace API.Controllers
{
    public class ScanController : ApiController
    {
        private readonly ScanRepository _rep = new ScanRepository();

        public IHttpActionResult Get()
        {
            var result = _rep.GetAll();
            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = _rep.Get(id);
            return Ok(result);
        }

        public IHttpActionResult Post(Scan scan)
        {
            _rep.Add(scan);
            return Ok();
        }
    }
}
