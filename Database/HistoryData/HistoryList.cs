using Database.File;
using Database.HistoryData;
using Database.RestaurantData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.HistoryData
{
    public class HistoryList
    {
        public List<HistoryInfoSum> GetHistoryList(String duration)
        {
            HistoryDataAccordingToDurationcs DataAccordingToDuration = new HistoryDataAccordingToDurationcs();
            List<Drink> DrinkInformationDurationList = DataAccordingToDuration.GetDataAccordingToDuration(duration);
            DistictHistoryData drinkSum = new DistictHistoryData();
            IEnumerable<HistoryInfoSum> list = drinkSum.GetListWithSum(DrinkInformationDurationList);
            
            return list.ToList();
        }
    }
}
