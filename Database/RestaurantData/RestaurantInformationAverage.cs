using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class RestaurantInformationAverage : IComparable <RestaurantInformationAverage>
    {
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("addres")]
        public String Address { get; set; }
        [JsonProperty("sumOfPercentage")]
        public int SumOfPercentage { get; set; }
        [JsonProperty("times")]
        public int Times { get; set; }
        [JsonProperty("averageOfPercentagee")]
        public double AverageOfPercentage { get; set; }

        public int CompareTo(RestaurantInformationAverage restraurantInformation)
        {
            return -1 * (AverageOfPercentage.CompareTo(restraurantInformation.AverageOfPercentage));
        }
    }
}
