using Database.File;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.HistoryData
{
    public class HistoryDataAccordingToDurationcs
    {
        public List<Drink> GetDataAccordingToDuration(String duration)
        {
            int days = 0;
            switch (duration)
            {
                case "Last Month (30 Days)":
                    days = 30;
                    break;
                case "Last Week (7 Days)":
                    days = 7;
                    break;
                default:
                    days = 7;
                    break;
            }
            ReadFromDbDrinkInfo<Drink> readingFromDb = new ReadFromDbDrinkInfo<Drink>();
            List<Drink> drinkList = readingFromDb.Read();
            List<Drink> dataListRange = new List<Drink>();
            foreach (Drink drinkData in drinkList)
            {
                if (DateTime.Compare(drinkData.Date.AddDays(days), DateTime.Today) >= 0)
                {
                    dataListRange.Add(drinkData);
                }
            }
            return dataListRange;
        }
    }
}