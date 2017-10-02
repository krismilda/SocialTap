using Services;
using social_tap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class GlassInformation
    {
        public String Name { get; set; }
        public String Address { get; set; }
        public int Percentage { get; set; }

        public async Task GetGlassInformation(Bitmap bitmap)
        {
            GooglePlacesApiData googleApiData = new GooglePlacesApiData();
            GooglePlacesApiResponse responseData = await googleApiData.GetApiResponseData("");
            Name = responseData.results[0].name;
            Address= responseData.results[0].vicinity;
            SimpleImageAnalysis imageInformation = new SimpleImageAnalysis(bitmap);
            int percentageOfLiquid = imageInformation.CalculatePercentageOfLiquid();
            Percentage = percentageOfLiquid;
        }
    }
}
