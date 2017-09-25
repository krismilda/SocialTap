using SocialTap.Location;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocialTap.Maps
{
    public class GoogleStaticMapApiData
    {
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
        String url = "https://maps.googleapis.com/maps/api/staticmap?center=" + currentCoordinates + "&zoom=" + zoom +
            "&size=600x300&markers=color:red%7Clabel:CA%7C" + currentCoordinates + "&markers=color:blue%7Clabel:1%7C"
            + placesList[0].coordinates + "&markers=color:blue%7Clabel:2%7C" + placesList[1].coordinates + "&markers=color:blue%7Clabel:3%7C"
            + placesList[2].coordinates + "&markers=color:blue%7Clabel:4%7C" + placesList[3].coordinates + "&markers=color:blue%7Clabel:5%7C"
            + placesList[4].coordinates + "&maptype=roadmap&key=AIzaSyC_baSbHRGypYfmIjAMbQTxJMSpbvB3w9w";
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
