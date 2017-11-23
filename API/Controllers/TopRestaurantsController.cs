using Database.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class TopRestaurantsController : ApiController
    {
        public IHttpActionResult Get([FromUri]string duration)
        {
            TopList customTopList = new TopList();
            List<RestaurantInformationAverage> list = customTopList.GetTopList(duration);
            return Ok(list);
        }
    }
}
