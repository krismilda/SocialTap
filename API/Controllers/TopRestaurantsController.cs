using DataAccess;
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
        SocialTapContext context = new SocialTapContext();
        public IHttpActionResult Get([FromUri]string duration)
        {

            switch (duration)
            {
                case "All Time":

                    var y = context.Restaurants.ToList();
                    var topList = context.Restaurants.Select(t => new
                    {
                        Name = t.Name,
                        Address = t.Address,
                        Average = t.Sum / t.Times
                    }).OrderByDescending(t=>t.Average).Take(10).ToList();
                    return Ok(topList);
                    break;
                case "Last Month (30 days)":

                    var topList2 = context.Scans.ToList()
                                .Where(t => (DateTime.Compare(t.Date.AddDays(30), DateTime.Today) >= 0))
                                .GroupBy(t => t.Place_Id).ToList()
                                .Select(g => new
                                {
                                    Average = g.Sum(x => x.Percentage) / g.Count(),
                                    Restaurant = g.Key
                                }).ToList()
                                .Join(context.Restaurants.ToList(), t => t.Restaurant, ta => ta.Id, (t, ta) => new { t.Average, ta.Name, ta.Address })
                                .OrderByDescending(t => t.Average)
                                .Take(10)
                                .ToList();
                    return Ok(topList2);
                    break;
                case "Last Week (7 days)":
                    var topList3 = context.Scans.ToList()
                                .Where(t => (DateTime.Compare(t.Date.AddDays(7), DateTime.Today) >= 0))
                                .GroupBy(t => t.Place_Id).ToList()
                                .Select(g => new
                                {
                                    Average = g.Sum(x => x.Percentage) / g.Count(),
                                    Restaurant = g.Key
                                }).ToList()
                                .Join(context.Restaurants.ToList(), t => t.Restaurant, ta => ta.Id, (t, ta) => new { t.Average, ta.Name, ta.Address })
                                .OrderByDescending(t => t.Average)
                                .Take(10)
                                .ToList();
                    return Ok(topList3);
                    break;
            }
            return Ok();
        }
    }
}