using DataModels;
using System.Web.Http;
using DataAccess;

namespace API.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantRepository _rep = new RestaurantRepository();

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

        public IHttpActionResult Post(Restaurant restaurant)
        {
            _rep.Add(restaurant);
            return Ok();
        }
    }
}
