using AndroidApp.Services;
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

namespace AndroidApp
{
    public class GooglePlacesApiData
    {

        public async Task<GooglePlacesApiResponse> GetApiResponseData(string type, string location)
        {
            HttpClient client = new HttpClient();
            string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?rankby=distance&location="
                + location + "&type="+type+"&key=AIzaSyAoqL_K1g-5kTuinL-60Tmcf9udFtc9SLg";
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url );

            HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);
            GooglePlacesApiResponse responseData = JsonConvert.DeserializeObject<GooglePlacesApiResponse>(await responseMessage.Content.ReadAsStringAsync());
            return responseData;
        }
    }
}
