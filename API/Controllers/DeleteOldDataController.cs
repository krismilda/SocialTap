using DataAccess;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class DeleteOldDataController : ApiController
    {
        SocialTapContext context = new SocialTapContext();

        [HttpGet]
        public IHttpActionResult Get()
        {
            var scans = context.Scans.ToList();
            foreach(Scan scan in scans)
            {
                if(DateTime.Compare(scan.Date.AddDays(30), DateTime.Today)<0)
                {
                    context.Scans.Remove(scan);
                    context.SaveChanges();
                }
            }
            return Ok();
        }
    }
}
