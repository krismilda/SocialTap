using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class TopList
    {
        public List<RestaurantInformationAverage> getTopList()
        {
            ReadingFromFile<RestaurantInformation> listFile = new ReadingFromFile<RestaurantInformation>();
            RestaurantInformationPecentageAverage restaurant = new RestaurantInformationPecentageAverage();
            List<RestaurantInformationAverage> listRestaurants = restaurant.GetListWithPercentageAverage(listFile.Read());
            listRestaurants.Sort();
            return listRestaurants;
        }

    }
}
