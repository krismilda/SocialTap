using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class CustomRangeOfData
    {
        public List<RestaurantInformationAverage>  GetLastDaysData(int days)
        {
            ReadingFromFile<RestaurantInformation> readingFromFile = new ReadingFromFile<RestaurantInformation>();
            List<RestaurantInformation> dataList= readingFromFile.Read();
            List<RestaurantInformation> dataListRange = new List<RestaurantInformation>();
            foreach(RestaurantInformation restaurantData in dataList)
            {
                if (restaurantData.Date.AddDays(days) >= DateTime.Today)
                {
                    dataListRange.Add(restaurantData);
                    Console.WriteLine(restaurantData.Date);
                }
            }
            RestaurantInformationPecentageAverage restaurant = new RestaurantInformationPecentageAverage();
            List<RestaurantInformationAverage> listRestaurants = restaurant.GetListWithPercentageAverage(dataListRange);
            return listRestaurants;

        }
    }
}
