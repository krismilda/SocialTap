using DataAccess;
using DataModels;
using Services.TwitterAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tweetinvi.Models;

namespace API.Controllers
{
    public class TweetController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            ListByTag tweetsList = new ListByTag();
            var tweets=tweetsList.GetListByTag();
            return Ok(tweets);
        }
        
    }
}
