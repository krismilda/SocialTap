using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Database.File
{
    public class DistictRestaurantsWithAverageOfPercentage
    {
        public List<RestaurantInformationAverage> GetListWithAverageOfPercentage(List<RestaurantInformation> listAllRestaurantInformation)
        {
            List<RestaurantInformationAverage> listRestaurantInformation = new List<RestaurantInformationAverage>();
            var listOfRestaurantsAverage = from restaurant in listAllRestaurantInformation
                                           group restaurant by new { restaurant.Name, restaurant.Address } into grouping
                                           select new RestaurantInformationAverage
                                           {
                                               Name = grouping.Key.Name,
                                               Address = grouping.Key.Address,
                                               SumOfPercentage = grouping.Sum(a => a.Percentage),
                                               Times = grouping.Count(),
                                               AverageOfPercentage = Math.Round(grouping.Average(a => a.Percentage), 2)
                                           };

            return listOfRestaurantsAverage.ToList<RestaurantInformationAverage>();
        }
    }
}
