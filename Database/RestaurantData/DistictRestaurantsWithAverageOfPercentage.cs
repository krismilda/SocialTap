using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class DistictRestaurantsWithAverageOfPercentage
    {
        public List<RestaurantInformationAverage> GetListWithAverageOfPercentage (List<RestaurantInformation> listAllRestaurantInformation)
        {
            List<RestaurantInformationAverage> listRestaurantInformation = new List<RestaurantInformationAverage>();
            Boolean ifAlreadyExist;
            foreach (RestaurantInformation restaurantDataInFile in listAllRestaurantInformation)
            {
                ifAlreadyExist = false;
                foreach (RestaurantInformationAverage restaurantAverageData in listRestaurantInformation)
                {
                    if (restaurantDataInFile.Name.Equals(restaurantAverageData.Name) && restaurantDataInFile.Name.Equals(restaurantAverageData.Name))
                    {
                        restaurantAverageData.SumOfPercentage += restaurantDataInFile.Percentage;
                        restaurantAverageData.Times++;
                        restaurantAverageData.AverageOfPercentage = restaurantAverageData.SumOfPercentage / restaurantAverageData.Times;
                        ifAlreadyExist = true;
                    }
                }
                if (!ifAlreadyExist)
                {
                    RestaurantInformationAverage restaurantInformationAverage = new RestaurantInformationAverage();
                    restaurantInformationAverage.Name = restaurantDataInFile.Name;
                    restaurantInformationAverage.Address = restaurantDataInFile.Address;
                    restaurantInformationAverage.AverageOfPercentage = restaurantDataInFile.Percentage;
                    restaurantInformationAverage.SumOfPercentage = restaurantDataInFile.Percentage;
                    restaurantInformationAverage.Times = 1;
                    listRestaurantInformation.Add(restaurantInformationAverage);
                }
            }
            return listRestaurantInformation;
        }
    }
}
