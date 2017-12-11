using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class MoneyHistoryController : ApiController
    {
        SocialTapContext context = new SocialTapContext();

        public IHttpActionResult GetCommon([FromUri]string duration)
        {
            switch (duration)
            {
                case "Last Month (30 days)":
                    var allMoney = context.Scans.ToList()
             .Where(t => (DateTime.Compare(t.Date.AddDays(30), DateTime.Today) >= 0))
             .Select(t => t.Price).Aggregate((a, b) => a + b);
                    var allMoneyRounded = Math.Round(allMoney, 2);
                    var lostMoney = context.Scans.ToList()
                                 .Where(t => (DateTime.Compare(t.Date.AddDays(30), DateTime.Today) >= 0))
                                 .Sum(t => (t.Price / t.Millimeters) * ((100 - t.Percentage) * 0.01 * t.Millimeters));
                    var lostMoneyRounded = Math.Round(lostMoney, 2);

                    return Ok(new { Money_Paid = allMoneyRounded, Money_Lost = lostMoneyRounded });
                    break;


                case "Last Week (7 days)":
                    var allMoney2 = context.Scans.ToList()
                                    .Where(t => (DateTime.Compare(t.Date.AddDays(7), DateTime.Today) >= 0))
                                    .Sum(t => t.Price);
                    var allMoneyRounded2 = Math.Round(allMoney2, 2);
                    var lostMoney2 = context.Scans.ToList()
                                    .Where(t => (DateTime.Compare(t.Date.AddDays(30), DateTime.Today) >= 0))
                                    .Sum(t => (t.Price / t.Millimeters) * ((100 - t.Percentage) * 0.01 * t.Millimeters));
                    var lostMoneyRounded2 = Math.Round(lostMoney2, 2);

                    return Ok(new { Money_Paid = allMoneyRounded2, Money_Lost = lostMoneyRounded2 });
                    break;
            }
            return Ok();
        }
    }
}
