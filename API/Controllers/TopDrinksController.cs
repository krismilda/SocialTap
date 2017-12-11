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
    public class TopDrinksController : ApiController
    {
        SocialTapContext context = new SocialTapContext();
        public IHttpActionResult Get([FromUri]string duration)
        {

            switch (duration)
            {
                case "Last Month (30 days)":
                    var scanList = context.Scans.ToList()
                        .Where(t => (DateTime.Compare(t.Date.AddDays(30), DateTime.Today) >= 0))
                        .ToList();
                    var drinks = from a in scanList
                                 group a by new { a.Place_Id, a.Drink } into b
                                 orderby b.Key.Place_Id, b.Sum(x => x.Millimeters) descending
                                 select new TopDrinks
                                 {
                                     Place_Id = b.Key.Place_Id,
                                     Drink = b.Key.Drink,
                                     Sum = b.Sum(x => x.Millimeters)
                                 };

                    var drinksList = drinks.ToList();
                    var restaurants = context.Restaurants.ToList();
                    List<DrinkTop> topDrinks = new List<DrinkTop>();

                    foreach(Restaurant r in restaurants)
                    {
                        DrinkTop d = new DrinkTop();
                        d.Name = r.Name;
                        d.Address = r.Address;
                        d.Millimeters = drinksList.First(t => (t.Place_Id == r.Id)).Sum;
                        d.Drink = drinksList.First(t => (t.Place_Id == r.Id)).Drink;
                        topDrinks.Add(d);
                    }
      
                    return Ok(topDrinks);
                    break;
                case "Last Week (7 days)":
                    var scanList2 = context.Scans.ToList()
                        .Where(t => (DateTime.Compare(t.Date.AddDays(7), DateTime.Today) >= 0))
                        .ToList();
                    var drinks2 = from a in scanList2
                                 group a by new { a.Place_Id, a.Drink } into b
                                 select new TopDrinks
                                 {
                                     Place_Id = b.Key.Place_Id,
                                     Drink = b.Key.Drink,
                                     Sum = b.Sum(x => x.Millimeters)
                                 };
                    var drinksList2 = drinks2.ToList();
                    var restaurants2 = context.Restaurants.ToList();
                    List<DrinkTop> topDrinks2 = new List<DrinkTop>();

                    foreach (Restaurant r in restaurants2)
                    {
                        DrinkTop d = new DrinkTop();
                        d.Name = r.Name;
                        d.Address = r.Address;
                        d.Millimeters = drinksList2.First(t => (t.Place_Id == r.Id)).Sum;
                        d.Drink = drinksList2.First(t => (t.Place_Id == r.Id)).Drink;
                        topDrinks2.Add(d);
                    }

                    return Ok(topDrinks2);
                    break;
            }
            return Ok();
        }
    }
}
