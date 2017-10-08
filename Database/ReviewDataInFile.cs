using Database.File;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Database
{
   public  class ReviewDataInFile
    {
        private Timer timer;

        private void SetUpTimer(TimeSpan alertTime)
        {
            DateTime current = DateTime.Now;
            TimeSpan timeToGo = alertTime - current.TimeOfDay;
            if (timeToGo < TimeSpan.Zero)
            {
                return;//time already passed
            }
            this.timer = new System.Threading.Timer(x =>
            {
               // this.SomeMethodRunsAt1600();
            }, null, timeToGo, Timeout.InfiniteTimeSpan);
        }

        public  static void SomeMethodRunsAt1600()
        {
            ReadingFromFileDeserialize<RestaurantInformation> readingFromFile = new ReadingFromFileDeserialize<RestaurantInformation>();
            List<RestaurantInformation> listOfRestaurants = readingFromFile.Read(fileName: ConfigurationManager.AppSettings["FileName"]);
            listOfRestaurants.Sort();
            foreach (RestaurantInformation restaurantInfo in listOfRestaurants)
            {
                Console.WriteLine(string.Format("{0:d}",restaurantInfo.Date));
            }
        }
    }
}
