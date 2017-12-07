using DataAccess;
using DataAccess.Repositories;
using DataModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    public class NewsController : ApiController
    {
        SocialTapContext context = new SocialTapContext();
 
        [HttpGet]
        public IHttpActionResult Get()
        {
     

            New news = new New();
            news.Date = DateTime.Today;
            news.Text = "labass";
            news.User_Id = "b0343219-5c8b-44be-8407-a747a6ff1a41";
            context.News.Add(news);
            try
            {
    context.SaveChanges();
            }
        catch(Exception e)
            {
                string g = e.ToString();
            }
            var newsList=context.News.ToList();
            return Ok(newsList);
        }

        // POST api/Account/Register
        [HttpPost]        
        public async Task<IHttpActionResult> Post(New news)
        {
            context.News.Add(news);
            context.SaveChanges();
            return Ok();
        }

    }
}