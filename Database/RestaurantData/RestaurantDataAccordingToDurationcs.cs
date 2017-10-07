﻿using Database.File;
using System;
using System.Collections.Generic;
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
            ReadingFromFile<RestaurantInformation> readingFromFile = new ReadingFromFile<RestaurantInformation>();
            List<RestaurantInformation> dataList = readingFromFile.Read();
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
