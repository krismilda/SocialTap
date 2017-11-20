using Database.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.RestaurantData
{
   public  class MostVisitedList
    {
        public List<RestaurantInformationAverage> GetMostVisitedList(String duration, String user, String username)
        {
            RestaurantDataAccordingToDurationcs restaurantDataAccordingToDuration = new RestaurantDataAccordingToDurationcs();
            List<RestaurantInformation> restaurantInformationDurationList = restaurantDataAccordingToDuration.GetDataAccordingToDuration(duration);
            if (user.Equals("Mine"))
            {
            var restaurantInformationDurationListMine = from res in restaurantInformationDurationList
                                                        where res.Username.Equals(username)
                                                        select res;
            restaurantInformationDurationList = restaurantInformationDurationListMine.ToList();
            }
            
            DistictRestaurantsWithAverageOfPercentage restaurant = new DistictRestaurantsWithAverageOfPercentage();
            List<RestaurantInformationAverage> listRestaurants = restaurant.GetListWithAverageOfPercentage(restaurantInformationDurationList);
            listRestaurants.OrderBy(a => a.Times);
            return listRestaurants;
        }
    }
}
