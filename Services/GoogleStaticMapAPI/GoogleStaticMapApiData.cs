using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Services
{
    
    public class GoogleStaticMapApiData
    {
        static String mapSize = "600x300";
        public List<NearbyPlace> placesList { get; set; }
        public GoogleStaticMapApiData()
        {
            placesList = new List<NearbyPlace>();
        }
        public async Task<Bitmap> GetMapResponseDataAsync(String type, String zoom)
        {
            CurrentCoordinate currentCoordinate = new CurrentCoordinate();
            currentCoordinate.CalculateCurrentCoordinates();
            String currentCoordinates = CoordinatesConverter.GetConvertedCoordinates(currentCoordinate.latitude, currentCoordinate.longitude);

            placesList.AddRange(await new NearbyPlacesList().GetNearbyPlacesListAsync(type));
            placesList.ToArray();
            String url = ConfigurationManager.AppSettings["GoogleStaticMapApiUrl"] + "&size="+mapSize+"&center=" + currentCoordinates + "&zoom=" + zoom + "&" + ConfigurationManager.AppSettings["GoogleStaticMapApiKey"];
            for (int i = 0; i < 5; i++)
            {
                url +="&" + ConfigurationManager.AppSettings["GoogleStaticMapApiMarker"] + placesList[0].coordinates;
            }
            Uri uri = new Uri(url);
            HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            Stream imageStream = httpResponse.GetResponseStream();
            Bitmap image = new Bitmap(imageStream);
            httpResponse.Close();
            imageStream.Close();
            return image;

        }
    }
}
