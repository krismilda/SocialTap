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
    public class TopDrinksController : ApiController
    {
        SocialTapContext context = new SocialTapContext();
       
        public IHttpActionResult Get([FromUri]string duration)
        {
            var list = context.Users.ToList().Where(x => x.Id == System.Web.HttpContext.Current.User.Identity.GetUserId());
            switch (duration)
            {
                case "Last Month (30 days)":
                    var scanList = context.Scans.ToList()
                        .Where(t => (DateTime.Compare(t.Date.AddDays(30), DateTime.Today) >= 0))
                      .Where(t => t.User_Id.Equals(list.First().Id))
                        .ToList();
                    var drinks = scanList.GroupBy(t => t.Drink).Select(t => new { Drink = t.Key, Sum = t.Sum(x => x.Millimeters) }).ToList();
                    return Ok(drinks);
                    break;
                case "Last Week (7 days)":
                    var scanList2 = context.Scans.ToList()
                        .Where(t => (DateTime.Compare(t.Date.AddDays(7), DateTime.Today) >= 0))
                        .Where(t => t.User_Id.Equals(list.First().Id))
                        .ToList();
                    var drinks2 = scanList2.GroupBy(t => t.Drink).Select(t => new { Drink = t.Key, Sum = t.Sum(x => x.Millimeters) }).ToList();
                    return Ok(drinks2);
                    break;
            }
            return Ok();
        }
    }
}
