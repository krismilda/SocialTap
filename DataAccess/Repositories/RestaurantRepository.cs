using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace DataAccess
{
    public class RestaurantRepository : BaseRepository<Restaurant>
    {
        new public void Add(Restaurant restaurant)
        {
            if (!_context.Restaurants.Contains(restaurant))
            {
                _context.Restaurants.Add(restaurant);
                _context.SaveChanges();
            }
        }
    }
}
