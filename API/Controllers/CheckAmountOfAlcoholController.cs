using DataAccess;
using DataModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class CheckAmountOfAlcoholController : ApiController
    {
        SocialTapContext context = new SocialTapContext();

        public IHttpActionResult Get()
        {
            var list = context.Users.ToList().Where(x => x.Id == System.Web.HttpContext.Current.User.Identity.GetUserId());
            var scanList = context.Scans.ToList()
                .Where(t => (DateTime.Compare(t.Date.AddDays(70), DateTime.Today) >= 0))
              .Where(t => t.User_Id.Equals(list.First().Id))
                .ToList();
            var drinks = scanList.GroupBy(t => t.Drink).Select(t => new TopDrinks{ Drink = t.Key, Sum = t.Sum(x => x.Millimeters*(x.Percentage*0.01)) }).ToList();
            double sum = 0;
            foreach(TopDrinks d in drinks)
            {
                if (d.Drink == "Beer"){
                    sum += (double)d.Sum / 250;
                }
                if (d.Drink == "Wine")
                {
                    sum += (double)d.Sum / 125;
                }
                if (d.Drink == "Liquer")
                {
                    sum += d.Sum / 50;
                }
                if (d.Drink =="Strong Drinks" )
                {
                    sum += d.Sum / 25;
                }
            }
            if (sum >= 14)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

    }
}

