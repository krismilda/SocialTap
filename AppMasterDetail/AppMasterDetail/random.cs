using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppMasterDetail
{
    class random
    {
        public static async void Buttonclick()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                var response = await client.GetAsync("http://localhost:58376/api/TopRestaurants");

                var responseString = await response.Content.ReadAsStringAsync();

            }
        }
    }
}
