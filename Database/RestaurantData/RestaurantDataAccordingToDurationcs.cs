using Database.File;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.RestaurantData
{
    public class RestaurantDataAccordingToDurationcs
    {
        public List<RestaurantInformation> GetDataAccordingToDuration(String duration)
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

            }
            ReadingFromFileDeserialize<RestaurantInformation> readingFromFile = new ReadingFromFileDeserialize<RestaurantInformation>();
            List<RestaurantInformation> dataList = readingFromFile.Read(fileName: ConfigurationManager.AppSettings["FileName"]);
            List<RestaurantInformation> dataListRange = new List<RestaurantInformation>();
            foreach (RestaurantInformation restaurantData in dataList)
            {
                if (DateTime.Compare(restaurantData.Date.AddDays(days), DateTime.Today) >= 0)
                {
                    dataListRange.Add(restaurantData);
                }
            }
            return dataListRange;
        }
    }
}
