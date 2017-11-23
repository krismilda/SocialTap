using Database.RestaurantData;
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
        public Restaurant Get()
        {
            Restaurant r = new Restaurant();
            r.Name = "Restr";
         //   MostVisitedList n = new MostVisitedList();
          //  var s= n.GetMostVisitedList("30 days",  "sd","sdf");
           // var res = new ListByTag().GetTweets();
            return r;
        }
    
    }
}
