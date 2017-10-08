using Services;
using social_tap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    [Serializable]
    public class RestaurantInformation : IEnumerable, IComparable<RestaurantInformation>
    {
        public DateTime Date { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public int Percentage { get; set; }

        public async Task GetGlassInformation(Bitmap bitmap)
        {
            GooglePlacesApiData googleApiData = new GooglePlacesApiData();
            GooglePlacesApiResponse responseData = await googleApiData.GetApiResponseData("food");
            SimpleImageAnalysis imageInformation = new SimpleImageAnalysis(bitmap);
            int percentageOfLiquid = imageInformation.CalculatePercentageOfLiquid();
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
