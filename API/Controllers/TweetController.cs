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
            ListByTag s = new ListByTag();
            var sa=s.GetListByTag();
            Tweet bv = new Tweet();
            bv.Text = "sdfsdf";
            bv.CreatedAt = DateTime.Today;
            bv.FavoriteCount = 5;
            sa.Add(bv);
            return Ok(sa);
        }
        [HttpPost]
        public IHttpActionResult Post(Restaurant r)
        {
            SocialTapContext s = new SocialTapContext();
            s.Restaurants.Add(r);
            s.SaveChanges();
            return Ok();
        }
        
    }
}
