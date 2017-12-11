using DataAccess;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class MoneyHistoryDrinkController : ApiController
    {
        SocialTapContext context = new SocialTapContext();

        public IHttpActionResult GetDrink([FromUri]string duration)
        {
            switch (duration)
            {
                case "Last Month (30 days)":

                    var moneyList2 = context.Scans.ToList()
                                .Where(t => (DateTime.Compare(t.Date.AddDays(30), DateTime.Today) >= 0))
                                .GroupBy(t => t.Drink).ToList()
                                .Select(g => new
                                {
                                    Drink = g.Key,
                                    Money_Paid = g.Sum(x => x.Price),
                                    Money_Lost = g.Sum(t => (t.Price / t.Millimeters) * ((100 - t.Percentage) * 0.01 * t.Millimeters))
                                }).ToList();
                    return Ok(moneyList2);
                    break;
                case "Last Week (7 days)":
                    var moneyList3 = context.Scans.ToList()
                              .Where(t => (DateTime.Compare(t.Date.AddDays(7), DateTime.Today) >= 0))
                              .GroupBy(t => t.Drink).ToList()
                              .Select(g => new
                              {
                                  Drink = g.Key,
                                  Money_Paid = g.Sum(x => x.Price),
                                  Money_Lost = g.Sum(t => (t.Price / t.Millimeters) * ((100 - t.Percentage) * 0.01 * t.Millimeters))
                              }).ToList();
                    return Ok(moneyList3);
                    break;
            }
            return Ok();
        }
    }
}
