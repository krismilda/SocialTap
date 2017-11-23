using Emgu.CV;
using Logic.ImageAnalysis;
using Newtonsoft.Json;
using Services.ImageAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database.HistoryData
{
    public class Drink
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("volume")]
        public int Volume { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("restaurant")]
        public RestaurantInformation Restaurant { get; set; }

        public void GetDrinkInformation(int percentageOfLiquid, int mililiter, string category)
        {
            Category = category;
            Volume = (mililiter / 100) * percentageOfLiquid;
            Date = DateTime.Today;
        }
    }
}

