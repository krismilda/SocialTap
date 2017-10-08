using Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class RestaurantAverageOfPercentage
    {
        public string GetAverageOfLiquid(RestaurantInformation restaurantInformation)
        {
            ReadingFromFileDeserialize<RestaurantInformation> restaurantListInFile = new ReadingFromFileDeserialize<RestaurantInformation>();
            DistictRestaurantsWithAverageOfPercentage distictRestaurantsWithAverage = new DistictRestaurantsWithAverageOfPercentage();
            List<RestaurantInformationAverage> restaurantsListWithAverage = distictRestaurantsWithAverage.GetListWithAverageOfPercentage(restaurantListInFile.Read(fileName:ConfigurationManager.AppSettings["FileName"]));
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
