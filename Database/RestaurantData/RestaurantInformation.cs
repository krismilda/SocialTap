using Emgu.CV;
using Services;
using Services.ImageAnalysis;
using System;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic.ImageAnalysis;
using Newtonsoft.Json;

namespace Database //todo perkelt i datamodels/isskaidyti
{
    [Serializable]
    public class RestaurantInformation : IComparable<RestaurantInformation> //todo paziuret ar ienumerable igyvendinamas butent taip
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("username")]
        public String Username { get; set; } //todo pakeist i User ir permigruot duombazej
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("address")]
        public String Address { get; set; }
        [JsonProperty("percentage")]
        public int Percentage { get; set; }

        public async Task GetRestaurantInformation(String path, PictureBox imageBox2, string username) //todo perkelt imagebox settinima i kita vieta
        {
            GooglePlacesApiData googleApiData = new GooglePlacesApiData();

            ICalculateLiquidPercentage rpa = new RealPhotoAnalysis(new Image<Emgu.CV.Structure.Bgr, byte>(path));
            //ICalculateLiquidPercentage rpa = new SimpleImageAnalysis(new System.Drawing.Bitmap(path));		 
            RealPhotoAnalysis rpa1 = (RealPhotoAnalysis)rpa;
            imageBox2.Image = rpa1.VisualRepresentation.Bitmap;
           // GooglePlacesApiResponse responseData = await googleApiData.GetApiResponseData("food");
            int percentageOfLiquid = rpa.CalculatePercentageOfLiquid();
            Username = username;
            Date = DateTime.Today;
           // Name = responseData.results[0].name;
       //     Address = responseData.results[0].vicinity;
            Percentage = percentageOfLiquid;
        }


        public int CompareTo(RestaurantInformation glass)
        {
            return -1 * (Date.CompareTo(glass.Date));
        }


    }
}
