
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class HistoryController : ApiController
    {
        public IHttpActionResult Get([FromUri]string duration)
        {
          //  HistoryList historyList = new HistoryList();
          //  List<HistoryInfoSum> list = historyList.GetHistoryList(duration);
            return Ok();
        }
        
    }
}