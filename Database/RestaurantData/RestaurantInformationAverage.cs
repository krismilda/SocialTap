using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class RestaurantInformationAverage : IEnumerable, IComparable <RestaurantInformationAverage>
    {
        public String Name { get; set; }
        public String Address { get; set; }
        public int SumOfPercentage { get; set; }
        public int Times { get; set; }
        public double AverageOfPercentage { get; set; }

        public int CompareTo(RestaurantInformationAverage restraurantInformation)
        {
            return -1 * (AverageOfPercentage.CompareTo(restraurantInformation.AverageOfPercentage));
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
