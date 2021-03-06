﻿using DataAccess;
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
    public class UploadScanController : ApiController
    {
        SocialTapContext context = new SocialTapContext();
        [HttpPost]
        public IHttpActionResult Post(RestaurantScan scan)
        {
        var list = context.Restaurants.Where(t => t.placesId == scan.Place_Id).Take(1).ToList();
            if (list.Count == 0)
            {
                Restaurant res = new Restaurant();
                res.placesId = scan.Place_Id;
                res.Name = scan.Name;
                res.Address = scan.Address;
                res.Sum = scan.Percentage;
                res.Times = 1;
                context.Restaurants.Add(res);
                context.SaveChanges();
                Scan scans = new Scan();
                var lista = context.Users.ToList().Where(x => x.Id == "897b973b-0050-4474-8e7c-858a3f53f2d2");
                scans.SocialTapUser = lista.First();
                scans.Date = DateTime.Today;
                scans.Percentage = scan.Percentage;
                scans.Millimeters = scan.Millimeters;
                scans.Drink = scan.Drink;
                scans.Price = scan.Price;
                scans.Restaurant = res;
                context.Scans.Add(scans);
                context.SaveChanges();
            }
            else
            {
                list.ElementAt(0).Times += 1;
                list.ElementAt(0).Sum += scan.Percentage;
                context.SaveChanges();
                Scan scans = new Scan();
                var lista = context.Users.ToList().Where(x => x.Id == "897b973b-0050-4474-8e7c-858a3f53f2d2");
                scans.SocialTapUser = lista.First();
                scans.Date = DateTime.Today;
                scans.Millimeters = scan.Millimeters;
                scans.Drink = scan.Drink;
                scans.Percentage = scan.Percentage;
                scans.Price = scan.Price;
                scans.Restaurant = list.ElementAt(0);
                context.Scans.Add(scans);
                context.SaveChanges();
            }
            return Ok();
        }
    }
}
