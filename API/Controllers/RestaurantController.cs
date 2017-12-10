using DataModels;
using System.Web.Http;
using DataAccess;
using System;
using System.Linq;

namespace API.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantRepository _rep = new RestaurantRepository();

        public IHttpActionResult Get()
        {

            SocialTapContext context = new SocialTapContext();
            Scan sc = new Scan();
            sc.Date = DateTime.Today.AddDays(-15);
            sc.Drink="Alcohol";
            sc.Percentage = 33;
            sc.Millimeters = 870;
            sc.Price = 5.80;
            var d = context.Restaurants.ToList();
            sc.Restaurant = d.ElementAt(0);
            //REIKIA DABARTINIO USERIO
            var list = context.Users.ToList();
            sc.SocialTapUser = list.ElementAt(0);
            //**************************************
            context.Scans.Add(sc);
            context.SaveChanges();
            var result = _rep.GetAll();
            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {

            var result = _rep.Get(id);
            return Ok(result);
        }

        public IHttpActionResult Post(Restaurant restaurant)
        {
            SocialTapContext context = new SocialTapContext();
            context.Restaurants.Add(restaurant);
            context.SaveChanges();
            return Ok();
        }
    }
}
