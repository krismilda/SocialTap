using Emgu.CV;
using Logic.ImageAnalysis;
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
        public int Id { get; set; }
        public string Category { get; set; }
        public int Volume { get; set; }
        public DateTime Date { get; set; }
        public RestaurantInformation Restaurant { get; set; }

        public void GetDrinkInformation(int percentageOfLiquid, int mililiter, string category)
        {
            Category = category;
            Volume = (mililiter / 100) * percentageOfLiquid;
            Date = DateTime.Today;
        }
    }
}

