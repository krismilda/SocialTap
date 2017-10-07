using Database.File;
using System;
using System.Collections.Generic;
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
            ReadingFromFile<RestaurantInformation> readingFromFile = new ReadingFromFile<RestaurantInformation>();
            List<RestaurantInformation> listOfRestaurants = readingFromFile.Read();
            listOfRestaurants.Sort();
            foreach (RestaurantInformation restaurantInfo in listOfRestaurants)
            {
                Console.WriteLine(string.Format("{0:d}",restaurantInfo.Date));
            }
        }
    }
}
