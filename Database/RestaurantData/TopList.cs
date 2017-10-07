using Database.RestaurantData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class TopList
    {
        public List<RestaurantInformationAverage> GetTopList(String duration)
        {
            RestaurantDataAccordingToDurationcs restaurantDataAccordingToDuration = new RestaurantDataAccordingToDurationcs();
            List <RestaurantInformation> restaurantInformationDurationList = restaurantDataAccordingToDuration.GetDataAccordingToDuration(duration);
            DistictRestaurantsWithAverageOfPercentage restaurant = new DistictRestaurantsWithAverageOfPercentage();
            List<RestaurantInformationAverage> listRestaurants = restaurant.GetListWithAverageOfPercentage(restaurantInformationDurationList);
            listRestaurants.Sort();
            return listRestaurants;
        }
    }
}
