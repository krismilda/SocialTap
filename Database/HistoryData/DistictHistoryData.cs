using System;
using System.Collections.Generic;
using System.Linq;

namespace Database.HistoryData
{
    public class DistictHistoryData
    {
        public List<HistoryInfoSum> GetListWithSum(List<Drink> listAllHistoryInformation)
        {
            List<HistoryInfoSum> listRestaurantInformation = new List<HistoryInfoSum>();
            var listOfDrinksSum = from drink in listAllHistoryInformation
                                  group drink by new { drink.Category } into grouping
                                  select new HistoryInfoSum
                                  {
                                      Category = grouping.Key.Category,
                                      SumOfMl = grouping.Sum(a => a.Volume),
                                  };

            return listOfDrinksSum.ToList();
        }

    }
}