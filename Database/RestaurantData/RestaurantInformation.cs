using Emgu.CV;
using Services;
using Services.ImageAnalysis;
using social_tap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    [Serializable]
    public class RestaurantInformation : IEnumerable, IComparable<RestaurantInformation>
    {
        public DateTime Date { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public int Percentage { get; set; }

        public async Task GetRestaurantInformation(String path, PictureBox imageBox2)
        {
            GooglePlacesApiData googleApiData = new GooglePlacesApiData();
            GooglePlacesApiResponse responseData = await googleApiData.GetApiResponseData("food");
            RealPhotoAnalysis rpa = new RealPhotoAnalysis(new Image<Emgu.CV.Structure.Bgr, byte>(path));
            imageBox2.Image = rpa.VisualRepresentation.Bitmap;
            int percentageOfLiquid = rpa.Percentage;
            Date = DateTime.Today;
            Name = responseData.results[0].name;
            Address = responseData.results[0].vicinity;
            Percentage = percentageOfLiquid;

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
