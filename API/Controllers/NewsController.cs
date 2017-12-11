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
            var newsList = context.News.ToList();
            var list = from news in newsList
                       select new
                       {
                           date = news.Date,
                           text = news.Text,
                           username = news.SocialTapUser.UserName
        };
           
            return Ok(list.ToList());
        }

        [HttpPost]        
        public IHttpActionResult Post(New news)
        {
            //*************************************
            //REIKIA DABARTINIO USERIO
            var list = context.Users.ToList().Where(x => x.Id == System.Web.HttpContext.Current.User.Identity.GetUserId());
            news.SocialTapUser = list.ElementAt(0);
            //**************************************
            context.News.Add(news);
            context.SaveChanges();
            return Ok();
        }

    }
}