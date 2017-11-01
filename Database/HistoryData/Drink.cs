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


        public async Task GetDrinkInformation(String path, PictureBox imageBox2, int mililiter, string category)
        {
            ICalculateLiquidPercentage rpa = new RealPhotoAnalysis(new Image<Emgu.CV.Structure.Bgr, byte>(path));
            //ICalculateLiquidPercentage rpa = new SimpleImageAnalysis(new System.Drawing.Bitmap(path));
            int percentageOfLiquid = rpa.CalculatePercentageOfLiquid();
            Category = category;
            Volume = (mililiter / 100) * percentageOfLiquid;
            Date = DateTime.Today;
        }
    }
}

