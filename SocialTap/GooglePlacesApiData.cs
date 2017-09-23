using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SocialTap
{
    public class CurrentLocationName
    {

        public async Task<GooglePlacesApiResponse> GetApiResponseData()
        {
            CurrentCoordinate currentCoordinate = new CurrentCoordinate();
            currentCoordinate.CalculateCurrentCoordinates();
            HttpClient client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get,"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location="+ currentCoordinate.GetCurrentCoordinates()+ "&rankby=distance&type=food&key=AIzaSyAoqL_K1g-5kTuinL-60Tmcf9udFtc9SLg");
            HttpResponseMessage responseMessage =await client.SendAsync(requestMessage);
            GooglePlacesApiResponse responseData = JsonConvert.DeserializeObject<GooglePlacesApiResponse>(await responseMessage.Content.ReadAsStringAsync());
            return responseData;
        }
    }
}
