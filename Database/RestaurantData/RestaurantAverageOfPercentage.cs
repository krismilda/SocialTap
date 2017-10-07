using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class RestaurantAverageOfPercentage
    {
        public string GetAverageOfLiquid(RestaurantInformation restaurantInformation)
        {
            ReadingFromFile<RestaurantInformation> restaurantListInFile = new ReadingFromFile<RestaurantInformation>();
            DistictRestaurantsWithAverageOfPercentage distictRestaurantsWithAverage = new DistictRestaurantsWithAverageOfPercentage();
            List<RestaurantInformationAverage> restaurantsListWithAverage = distictRestaurantsWithAverage.GetListWithAverageOfPercentage(restaurantListInFile.Read());
            foreach (RestaurantInformationAverage restaurantInformationAveraged in restaurantsListWithAverage)
            {
                if (restaurantInformationAveraged.Name.Equals(restaurantInformation.Name) && restaurantInformationAveraged.Address.Equals(restaurantInformation.Address))
                {
                    return restaurantInformationAveraged.AverageOfPercentage.ToString();
                }
            }
            return "-";
        }
    }
}
