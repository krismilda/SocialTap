using Database.File;
using Database.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class NewsController : ApiController
    {
        public IHttpActionResult Get()
        {
            ReadingNewFromDatabase reading = new ReadingNewFromDatabase();
            List<New> newsList = reading.Read("Today");
            return Ok(newsList);
        }
    }
}
