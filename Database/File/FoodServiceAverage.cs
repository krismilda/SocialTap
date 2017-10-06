using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class FoodServiceAverage
    {
        public static string getAverageOfLiquid(RestaurantInformation restaurantInformation)
        {
            ReadingFromFile<RestaurantInformation> listFile = new ReadingFromFile<RestaurantInformation>();
            RestaurantInformationPecentageAverage restaurant = new RestaurantInformationPecentageAverage();
            List<RestaurantInformationAverage> listRestaurants = restaurant.GetListWithPercentageAverage(listFile.Read());
            foreach (RestaurantInformationAverage restaurantsInformation in listRestaurants)
            {
                if (restaurantsInformation.Name.Equals(restaurantInformation.Name) && restaurantsInformation.Address.Equals(restaurantInformation.Address))
                {
                    return restaurantsInformation.AverageOfPercentage.ToString();
                }
            }
            return "-";
        }
    }
}
