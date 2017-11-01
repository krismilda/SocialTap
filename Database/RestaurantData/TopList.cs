using Database.RestaurantData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Database.File
{
    public class TopList
    {
        public List<RestaurantInformationAverage> GetTopList(String duration)
        {
            RestaurantDataAccordingToDurationcs restaurantDataAccordingToDuration = new RestaurantDataAccordingToDurationcs();
            List <RestaurantInformation> restaurantInformationDurationList = restaurantDataAccordingToDuration.GetDataAccordingToDuration(duration);
            DistictRestaurantsWithAverageOfPercentage restaurantAverage = new DistictRestaurantsWithAverageOfPercentage();
            IEnumerable<RestaurantInformationAverage> listRestaurants = restaurantAverage.GetListWithAverageOfPercentage(restaurantInformationDurationList);
            listRestaurants = listRestaurants.OrderByDescending(n => n.AverageOfPercentage);
            return listRestaurants.ToList<RestaurantInformationAverage>();
        }
    }
}
