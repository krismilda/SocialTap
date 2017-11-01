using Emgu.CV;
using Services;
using Services.ImageAnalysis;
using System;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic.ImageAnalysis;

namespace Database
{
    [Serializable]
    public class RestaurantInformation : IEnumerable, IComparable<RestaurantInformation>
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public DateTime Date { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public int Percentage { get; set; }

        public async Task GetRestaurantInformation(String path, PictureBox imageBox2)
        {
            GooglePlacesApiData googleApiData = new GooglePlacesApiData();
            GooglePlacesApiResponse responseData = await googleApiData.GetApiResponseData("food");
            ICalculateLiquidPercentage rpa = new RealPhotoAnalysis(new Image<Emgu.CV.Structure.Bgr, byte>(path));
            //ICalculateLiquidPercentage rpa = new SimpleImageAnalysis(new System.Drawing.Bitmap(path));
            int percentageOfLiquid = rpa.CalculatePercentageOfLiquid();
            Date = DateTime.Today;
            Name = responseData.results[0].name;
            Address = responseData.results[0].vicinity;
            Percentage = percentageOfLiquid;
            RealPhotoAnalysis rpa1 = (RealPhotoAnalysis)rpa;
            imageBox2.Image = rpa1.VisualRepresentation.Bitmap;

        }
        public int CompareTo(RestaurantInformation glass)
        {
            return -1 * (this.Date.CompareTo(glass.Date));
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
