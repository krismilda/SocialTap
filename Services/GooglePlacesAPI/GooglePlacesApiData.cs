using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Services
{
    public class GooglePlacesApiData
    {

        public async Task<GooglePlacesApiResponse> GetApiResponseData(String type)
        {
            CurrentCoordinate currentCoordinate = new CurrentCoordinate();
            currentCoordinate.CalculateCurrentCoordinates();
            String currentCoordinates = CoordinatesConverter.GetConvertedCoordinates(currentCoordinate.latitude, currentCoordinate.longitude);
            HttpClient client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get,
                ConfigurationManager.AppSettings["GooglePlacesApiUrl"] + "&location="
                + currentCoordinates + "&type=" + type + "&"
                + ConfigurationManager.AppSettings["GooglePlacesApiKey"]);

            HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);
            GooglePlacesApiResponse responseData = JsonConvert.DeserializeObject<GooglePlacesApiResponse>(await responseMessage.Content.ReadAsStringAsync());
            return responseData;
        }
    }
}
