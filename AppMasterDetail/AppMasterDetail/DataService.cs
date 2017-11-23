using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppMasterDetail
{
    public static class DataService
    {
        public static async Task getDataFromService()
        {
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            var uri = new Uri("http://drinklyapi20171122074316.azurewebsites.net/api/TopRestaurants");

            var response = await client.GetAsync(uri);
            string json = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<Restaurant>(json);
            string s = data.Name;
            int a = 5;
        }
    }
}
